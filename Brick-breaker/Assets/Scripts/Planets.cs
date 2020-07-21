using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform centre;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.forward, -.5f * Time.fixedDeltaTime * 200f);
    }
}
