using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    // Variables

    public GameObject plattform;
    public GameObject diamond;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    public static PlatformSpawner instance;
    //Methods 


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        lastPos = plattform.transform.position;
        size = plattform.transform.localScale.x;
        
    }
    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatform", 0.3f, 0.3f);
    }
    public void PauseSpawning()
    {
        CancelInvoke("SpawnPlatform");
    }
    public void ResumeSpawning()
    {
        InvokeRepeating("SpawnPlatform", 0.3f, 0.3f);
    }

    // Update is called once per frame

    void Update()
    {
        if (gameOver)
        {
            CancelInvoke("SpawnPlatform");
        }

    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        
        Instantiate(plattform, pos, Quaternion.identity);

        int random = Random.Range(0, 4);
        if( random > 2)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
        
    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(plattform, pos,Quaternion.identity);
        int random = Random.Range(0, 4);
        if (random > 2)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }
    void SpawnPlatform()
    {


       int random = Random.Range(0 , 9);
        if(random < 3)
        {
            SpawnX();
        }
        else if ( random >= 3 && random < 6)
        {
            SpawnZ();
        }
        else if ( random >=6 && random < 9)
        {
            SpawnX();
            SpawnZ();
        }
    }

}
