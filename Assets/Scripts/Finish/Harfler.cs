using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harfler : MonoBehaviour
{
   

    private bool col;
    
    private void Update() {


        

        if(col)
        {
            GetComponent<Rigidbody>().freezeRotation = false;
             GetComponent<Rigidbody>().useGravity = true;
             
             
        }
        else
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().freezeRotation = true;

        }
        

    }
    
    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            col = true;
        }
    }

    
    
}
