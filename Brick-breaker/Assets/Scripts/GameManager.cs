using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager _instance;
    public GameObject button;
    private int bricknum = 18;
    private int prevActiveSceneIndex;
    public GameObject pan;
    public bool isPaused = false;
    private int score = 0;
    public Text scoreText;
    public Image[] hearts;

    public static GameManager Instance
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

    public void Awake()
    {
        _instance = this;
    }

    public void UpdateBricks()
    {
        bricknum--;
        if (bricknum == 0)
        {
            nss();
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void nss()
    {
        prevActiveSceneIndex = SceneManager.GetActiveScene().buildIndex;
        pan.SetActive(true);
        button.SetActive(true);
        isPaused = true;

    }

    public void Next()
    {
        SceneManager.LoadScene(prevActiveSceneIndex + 1);
        button.SetActive(false);
        pan.SetActive(false);
        isPaused = false;
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "SCORE " + score.ToString();
    }

    private int l = 3;
    public void UpdateLives(int livesRemaining)
    {
        if (livesRemaining > l)
        {
            hearts[livesRemaining - 1].color = Color.white;
        }
        else
        {
            hearts[livesRemaining].color = Color.grey;
            l = livesRemaining;
        }
    }
}
