using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D bd;
    float x;
    void Start()
    {
        bd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.acceleration.x;
        if(GameManager.Instance.isPaused == false)
        {
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.68f, 7.68f),transform.position.y);
        }
        bd.velocity = new Vector2(x * 10.0f, bd.velocity.y);
    }
}
