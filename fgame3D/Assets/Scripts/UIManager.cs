using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame updat
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public GameObject tapText;
    public static UIManager instance;
    public GameObject pausePanel;
    public GameObject pauseButton;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        highScore1.text = PlayerPrefs.GetInt("highScore").ToString();
        tapText.SetActive(false);
        startPanel.GetComponent<Animator>().Play("PanelAnimation");
        pauseButton.SetActive(true);

    }
    public void GameOver()
    {
        pauseButton.SetActive(false);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        

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
}
