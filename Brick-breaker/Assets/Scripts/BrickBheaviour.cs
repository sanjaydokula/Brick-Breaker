using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBheaviour : MonoBehaviour, IDamgeable
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject crumblePrefab;
    //public GameObject[] powerPrefab = new GameObject[3];
    [SerializeField]
    private GameObject powerPrefab;
    public int health = 2;
    public void Start()
    {
        Health = health;
    }
    public int Health { get; set; }

    public void Damage()
    {
        if (Health == 1)
        {
            Destroy(gameObject);
            GameManager.Instance.UpdateScore();
            GameManager.Instance.UpdateBricks();
            GameObject prefab = Instantiate(crumblePrefab, transform.position, transform.rotation) as GameObject;
            Destroy(prefab, 2.0f);
            float rand = Random.value * 10;
            if (rand < 1)
            {
                Debug.Log("Drop.");
                int randi = (int)rand;
                Drop(randi);
            }
        }
        else
        {
            Health--;
            Debug.Log(Health);
        }
    }

    public void Drop(int rand)
    {
       // float i = Random.value*3
        GameObject prefab = Instantiate(powerPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(prefab, 10.0f);
        prefab.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 50.0f);

    }
}
