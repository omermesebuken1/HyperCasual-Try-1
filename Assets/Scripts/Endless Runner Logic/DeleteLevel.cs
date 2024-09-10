using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteLevel : MonoBehaviour
{
    
    
    public GameObject ThisLevel;
    
    

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(ThisLevel);
           
        }

    }
}
