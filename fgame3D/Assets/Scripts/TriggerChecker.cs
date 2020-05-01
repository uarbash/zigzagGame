using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Variables 


    


    // Methods 




    void Start()
    {
        
    }

    // Updat
    void Update()
    {
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.1f);
        }
    }
    void FallDown()
    {
        GetComponentInParent<Rigidbody>().isKinematic = false;
        GetComponentInParent<Rigidbody>().useGravity = true;
        
        Destroy(transform.parent.gameObject,0.5f);
    }
}
