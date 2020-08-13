using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBheaviour : MonoBehaviour, IDamgeable
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject crumblePrefab;


    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.forward, -1f * Time.fixedDeltaTime * 50f);
    }

    public void Damage()
    {
        // if (Health == 1)
        //{
        AudioManager so = FindObjectOfType<AudioManager>();
        so.PlayS("Boom");
        Destroy(this.gameObject);
        GameManager.Instance.UpdateScore();
        //GameManager.Instance.UpdateBricks();
        GameObject prefab = Instantiate(crumblePrefab, transform.position, transform.rotation) as GameObject;
        Destroy(prefab, 2.0f);
    }
}
