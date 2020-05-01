using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Destroy(transform.gameObject);
            GameObject storedPartical = Instantiate(Partical, transform.position, Quaternion.identity);
            Destroy(storedPartical, 1f);
        }
    }
}
