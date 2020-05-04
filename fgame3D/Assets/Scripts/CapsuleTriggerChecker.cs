using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleTriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Physics.Raycast(transform.position, Vector3.down, 10f))
        {
            Invoke("DestroyCapsule", 5f);
        }
    }
    void DestroyCapsule()
    {
        Destroy(gameObject);
    }
}
