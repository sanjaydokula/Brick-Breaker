using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private PaddleControl paddle;
    private Rigidbody2D rigidbody;
    public bool inPlay = false;
    public Transform ballPos;
    //private BrickBheaviour brick;
   


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        paddle = GameObject.FindGameObjectWithTag("Player").GetComponent<PaddleControl>();
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
            //Debug.Log("jump!");
            rigidbody.AddForce(Vector2.up * 350);
            inPlay = true;
        }
        /*  if (transform.position.y > 4.997)
          {
              transform.position = new Vector2(rigidbody.velocity.x, -5.56f);
          }*/

        Vector2 vel = rigidbody.velocity;
        Vector2 maxvel = new Vector2(10.0f, 10.0f);
        Vector2 minvel = new Vector2(8.0f, 8.0f);
        Vector2 direction = rigidbody.velocity;
        if (direction.y > 0)
        {

            if (vel.x > maxvel.x || vel.y > maxvel.y)
            {
                Debug.Log("max reached.");
                Debug.Log(vel);
                rigidbody.velocity = vel * 0.8f;
            }
        }
        if (direction.y < 0)
        {
            if ( vel.y < -minvel.y)
            {

                Debug.Log("minimum reached.");
                Debug.Log(vel);
                //rigidbody.velocity = new Vector2(vel.x,vel.y * 0.8f);
                rigidbody.velocity = vel * 0.8f;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            //Debug.Log("hit wall");
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
            //Debug.Log("hit: " + other.gameObject.name);
            IDamgeable hit = other.gameObject.GetComponent<IDamgeable>();
            if (hit != null)
            {
                hit.Damage();
            }

        }
    }
}
