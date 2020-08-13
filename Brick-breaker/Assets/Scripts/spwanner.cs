using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spwanner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Brick").Length < 6)
        {
            int randn = Random.Range(3, 5);
            for (int i = 0; i < randn; i++)
            {
                int rand = Random.Range(0, 13);
                GameManager.Instance.spwanPlanets(rand);
            }
        }
    }

    //public IEnumerable
}
