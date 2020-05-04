using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame upd
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public GameObject tapText;
    public static UIManager instance;
    public GameObject pausePanel;
    public GameObject pauseButton;
    public GameObject startButton;
    public GameObject onExitPanel;
    public Text currentScore;
    public GameObject showCurrentScore;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highScore1.text = "High Score : "+PlayerPrefs.GetInt("highScore").ToString();
    }

    // Update is called once per 
    void Update()
    {
        currentScore.text = PlayerPrefs.GetInt("currentScore").ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            onExitPanel.SetActive(true);
            Ball.instance.GameWillBeExit();
            startPanel.SetActive(false);
            startButton.SetActive(false);
            pauseButton.SetActive(false);
        }

    }

    public void GameStart()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
        tapText.SetActive(false);
        startPanel.GetComponent<Animator>().Play("PanelAnimation");
        pauseButton.SetActive(true);
        startButton.SetActive(false);
        showCurrentScore.SetActive(true);

    }
    public void GameOver()
    {
        pauseButton.SetActive(false);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        showCurrentScore.SetActive(false);


    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    public void GameIsPaused()
    {
        pauseButton.SetActive(false);
        pausePanel.SetActive(true);
    }
    public void GameIsResumed()
    {
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void DontEXitGame()
    {
        onExitPanel.SetActive(false);
        Ball.instance.GameWontExit();
        

    }
}
