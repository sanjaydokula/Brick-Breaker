using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameManager _instance;
    private Accel accel;
    private PaddleControl paddleControl;

    public GameObject playagain, backtomenu, pause, options;
    public GameObject gameover;

    public Button left, right, start;


    public bool isPaused = false;
    public int score = 0;
    private float duration = 10.0f;
    private float elapsedTime;


    public Text scoreText;
    public Text highScoreText;
    private Text startText;
    public Button startButton;

    public Image[] hearts;
    public Transform[] spwanPoints;
    public GameObject[] planet;

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
    public void Start()
    {
        highScoreText.text = "HighScore" + "\n" + PlayerPrefs.GetInt("highscores", 0).ToString();
        accel = GameObject.FindGameObjectWithTag("Player").GetComponent<Accel>();
        paddleControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PaddleControl>();
        startText = start.GetComponentInChildren<Text>();

        paddleControl.enabled = true;
        accel.enabled = false;

    }
    private void Update()
    {
        if (Time.time > 8.0f)
        {

            if (elapsedTime < duration)
            {

                left.image.color = Color32.Lerp(left.image.color, new Color32(0, 0, 0, 0), elapsedTime / duration);
                right.image.color = Color32.Lerp(right.image.color, new Color32(0, 0, 0, 0), elapsedTime / duration);
                start.image.color = Color32.Lerp(start.image.color, new Color32(0, 0, 0, 0), elapsedTime / duration);
                startText.color = Color32.Lerp(startText.color, new Color32(0, 0, 0, 0), elapsedTime / duration);
                elapsedTime += Time.deltaTime;
            }
        }

    }
    public void Awake()
    {
        _instance = this;
        /*if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            bricknum = 18;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            bricknum = 24;
        }*/
    }

    /*public void UpdateBricks()
    {
        bricknum--;
        if (bricknum == 0 && SceneManager.GetActiveScene().buildIndex != 2)
        {
           // nss();
        }
        else if (bricknum == 0 && SceneManager.GetActiveScene().buildIndex == 2)
        {
            end.SetActive(true);
            isPaused = true;
        }
    }*/
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //bricknum = 18;
        Debug.Log("Game Start.");
        playagain.SetActive(false);
        gameover.SetActive(false);
        highScoreText.enabled = false;


    }
    public void Options()
    {
        options.SetActive(true);
        isPaused = true;
    }
    public void Quit()
    {
        Application.Quit();
    }



    public void Back()
    {
        SceneManager.LoadScene(0);
        backtomenu.SetActive(false);
        gameover.SetActive(false);
        highScoreText.enabled = false;
        Time.timeScale = 1.0f;


    }

    public void Pause()
    {
        pause.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }
    public void Resume()
    {
        pause.SetActive(false);
        options.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    /* public void nss()
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
         if (SceneManager.GetActiveScene().buildIndex == 2)
         {
             bricknum = 24;
         }
     }*/

    public void ControlSettings(int id)
    {
        if (id == 0)
        {

            accel.enabled = false;
            paddleControl.enabled = true;
        }
        else if (id == 1)
        {
            accel.enabled = true;
            //paddleControl.enabled = false;
            left.enabled = false;
            right.enabled = false;
        }
    }
    public void UpdateScore()
    {
        score += 10;
        //PlayerPrefs.SetInt("score", score);
        scoreText.text = "SCORE " + score.ToString();
        // Debug.Log("Before Playerfklds");
        //Debug.Log(PlayerPrefs.GetInt(""))
        if (PlayerPrefs.GetInt("highscores") < score)
        {
            Debug.Log("New HighScore!");
            highScoreText.text = "HighScore " + "\n" + score.ToString();
            PlayerPrefs.SetInt("highscores", score);

        }
        else
        {
            int hs = PlayerPrefs.GetInt("highscores");
            highScoreText.text = "HighScore " + "\n" + hs.ToString();
            Debug.Log("Highscore: " + PlayerPrefs.GetInt("highscores"));
        }

    }

    private int l = 3;
    public void UpdateLives(int livesRemaining)
    {
        if (livesRemaining == 0)
        {
            Debug.Log("gameOver");
            gameover.SetActive(true);
            playagain.SetActive(true);
            backtomenu.SetActive(true);
            highScoreText.enabled = true;
            isPaused = true;
        }
        else if (livesRemaining > l)
        {
            hearts[livesRemaining - 1].color = Color.white;
        }
        else
        {
            hearts[livesRemaining].color = Color.grey;
            l = livesRemaining;
        }
    }

    public void spwanPlanets(int rand)
    {

        Instantiate(planet[Random.Range(0, 6)], spwanPoints[rand].position, Quaternion.identity);
    }
}
