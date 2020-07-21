using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    private BallBehaviour ball;
    private Rigidbody2D ballRigidBody;
    public float leftEdge;
    public float rightEdge;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int lives = 3;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallBehaviour>();
        ballRigidBody = ball.GetComponent<Rigidbody2D>();

        leftEdge = -9.73f;
        rightEdge = 9.73f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPaused == true)
        {
            ballRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
            return;
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        if (ball.inPlay == false)
        {
            if (transform.position.x < -7.68f)
            {
                transform.position = new Vector2(-7.68f, transform.position.y);
            }
            else if (transform.position.x > 7.64f)
            {
                transform.position = new Vector2(7.64f, transform.position.y);
            }
        }
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        else if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }

        /* if (Input.GetKeyDown(KeyCode.N))
         {
             SceneManager.LoadScene(1);
         }*/
    }
    /*
     * This method 
     */
    public void Reset()
    {
        --lives;
        GameManager.Instance.UpdateLives(lives);
        if (lives == 0)
        {
            //PlayerPrefs.SetInt("highscore", int.Parse(GameManager.Instance.highscore.ToString()));
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            transform.position = new Vector2(0.0f, transform.position.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Life"))
        {
            if (lives < 3)
            {
                lives++;
                GameManager.Instance.UpdateLives(lives);
            }
            Destroy(collision.gameObject);
        }
    }
}
