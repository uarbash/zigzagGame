using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public int highScore;
    public bool gameStarted;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void IncreaseScore()
    {
        if (PlayerPrefs.GetInt("pause") == 0)
        {
            score += 1;
            PlayerPrefs.SetInt("currentScore", score);
        }   
    }
    public void StartScore()
    {
        InvokeRepeating("IncreaseScore", 0.1f, 0.5f);
    }
    public void StopScore()
    {
        CancelInvoke("IncreaseScore");
        PlayerPrefs.SetInt("score", score );
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
