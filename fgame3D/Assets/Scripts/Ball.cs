using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    Rigidbody rb;
    public bool gameStarted;
    public bool gameOver;
    public bool gameIsPaused; 
    public static Ball instance;
    bool right;
    public bool startMoving;
    LineRenderer lr;
    // Start is called before the first frame updatep

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lr = GetComponent<LineRenderer>();
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
    }

    // Update is called once per 
    void Update()
    {
        if (!startMoving)
        {
            if (gameStarted)
            {
              // if (Input.GetMouseButtonDown(0))
               // {
                    rb.velocity = new Vector3(speed, 0, 0);
                 //   gameStarted = true;
                    GameManager.instance.GameStarted();
                startMoving = true;
             //  }
            }
             
        }


        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if ( !Physics.Raycast(transform.position, Vector3.down, 30f) && !gameOver)
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFall>().gameOver = true;
            PlatformSpawner.instance.gameOver = true;
            GameManager.instance.GameOver();
            lr.SetPosition(1, new Vector3(transform.position.x, 0f, transform.position.z));
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            rb.AddForce(0, 25 , 0);
        }

        if (Input.GetMouseButtonDown(0) && !gameOver && !gameIsPaused)
        {
            SwitchDirection();
        }
        if( !gameOver)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, new Vector3(transform.position.x, -20f, transform.position.z));
        }


    }
    void SwitchDirection()
    {
        

        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);

        }
        else if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }

    }
    public void GameIsPaused()
    {
        if(rb.velocity.x > 0)
        {
            right = true;
        }
        if (rb.velocity.z > 0)
        {
            right = false;
        }
        rb.velocity = new Vector3(0, 0, 0);
        PlatformSpawner.instance.PauseSpawning();
        UIManager.instance.GameIsPaused();
        gameIsPaused = true;
    }
    public void GameIsResumed()
    {
        if (gameStarted)
        {
            PlatformSpawner.instance.ResumeSpawning();
            if (right)
            {
                rb.velocity = new Vector3(0, 0, speed);
            }
            if (!right)
            {
                rb.velocity = new Vector3(speed, 0, 0);
            }
            UIManager.instance.pauseButton.SetActive(true);
            gameIsPaused = false;
        }
        else
        {
            UIManager.instance.startPanel.SetActive(true);
            UIManager.instance.startButton.SetActive(true);
        }
        
    }
    public void GameWillBeResumed()
    {
        Invoke("GameIsResumed", 0.5f);
    }
    public void StartGame()
    {
        gameStarted = true;
    }
    public void GameWillBeExit()
    {
        if (rb.velocity.x > 0)
        {
            right = true;
        }
        if (rb.velocity.z > 0)
        {
            right = false;
        }
        rb.velocity = new Vector3(0, 0, 0);
        PlatformSpawner.instance.PauseSpawning();
        gameIsPaused = true;
    }
    public void GameWontExit()
    {
        GameWillBeResumed();
    }
}
