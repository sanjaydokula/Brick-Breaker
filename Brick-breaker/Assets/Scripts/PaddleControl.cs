using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleControl : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    public float leftEdge;
    public float rightEdge;
    [SerializeField]
    private float speed = 5.0f;
    private int lives = 3;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        leftEdge = -9.73f;
        rightEdge = 9.73f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
        if (transform.position.x < leftEdge)
        {
            transform.position = new Vector2(rightEdge, transform.position.y);
        }
        else if (transform.position.x > rightEdge)
        {
            transform.position = new Vector2(leftEdge, transform.position.y);
        }
    }
    /*
     * This method 
     */
    public void Reset()
    {
        --lives;
        if (lives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            transform.position = new Vector2(0.0f, transform.position.y);
        }
    }
}
