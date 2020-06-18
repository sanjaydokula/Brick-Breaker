using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private PaddleControl paddle;
    private Rigidbody2D rigidbody;
    private bool inPlay = false;
    public Transform ballPos;
    public GameObject crumblePrefab;
    //private BrickBheaviour brick;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindGameObjectWithTag("Player").GetComponent<PaddleControl>();
       // brick = GameObject.FindGameObjectWithTag("Brick").GetComponent<BrickBheaviour>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!inPlay)
        {
            transform.position = ballPos.position;
        }
        if (Input.GetKeyDown(KeyCode.Space) && inPlay == false)
        {
            Debug.Log("jump!");
            rigidbody.AddForce(Vector2.up * 400);
            inPlay = true;
        }
        if (transform.position.y > 4.997)
        {
            transform.position = new Vector2(rigidbody.velocity.x, -5.56f);
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("hit wall");
            rigidbody.velocity = new Vector2(0.0f, 0.0f);
            transform.position = new Vector2(0.0f, -4.45f);
            inPlay = false;
            paddle.Reset();

        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Brick"))
        {
            Debug.Log("hit: " + other.gameObject.name);
            IDamgeable hit = other.gameObject.GetComponent<IDamgeable>();
            if(hit!= null)
            {
                hit.Damage();
            }
          
        }
    }
}
