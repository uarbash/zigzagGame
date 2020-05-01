using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if ( instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("pause", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStarted()
    {
        ScoreManager.instance.StartScore();
        UIManager.instance.GameStart();
        GameObject.Find("PattformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }
    public void GameOver()
    {
        UnityAdManager.instance.ShowAd();
        ScoreManager.instance.StopScore();
        UIManager.instance.GameOver();
    }
    public void GameIsPaused()
    {
        
    }
}
