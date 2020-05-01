using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        PlayerPrefs.SetInt("pause", 1);
        Ball.instance.GameIsPaused();
    }
    public void Resume()
    {
        PlayerPrefs.SetInt("pause", 0);
        Ball.instance.GameWillBeResumed();
        UIManager.instance.GameIsResumed();
    }
    public void DoExitGame()
    {
        Application.Quit();
    }
}
