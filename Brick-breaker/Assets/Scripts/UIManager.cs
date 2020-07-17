using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pan;
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("null instance.");
            }
            return _instance;
        }
    }

    public void Level()
    {

        pan.SetActive(true);
    }
}
