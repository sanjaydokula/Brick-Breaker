using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBheaviour : MonoBehaviour,IDamgeable
{
    // Start is called before the first frame update
    public GameObject crumblePrefab;

    public int Health { get; set; }

    public void Damage()
    {
        Destroy(gameObject);
        GameObject prefab = Instantiate(crumblePrefab, transform.position, transform.rotation) as GameObject;
        Destroy(prefab, 2.0f);
    }
}
