using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondTriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Partical;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 10f))
        {
            Invoke("DestroyDiamond", 1f);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            GameObject.Find("CurrentScore").GetComponent<Animator>().Play("ScoreBonus");
            Destroy(transform.gameObject);
            GameObject storedPartical = Instantiate(Partical, transform.position, Quaternion.identity);
            Destroy(storedPartical, 1f);
            
        }
    }
    void DestroyDiamond()
    {
        Destroy(gameObject);
    }
}
