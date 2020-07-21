using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonM : MonoBehaviour
{
    // Start is called before the first frame update
    private static ButtonM _instance;

    public static ButtonM Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("no reference to instance.");
            }
            return _instance;
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
}

