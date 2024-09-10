using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    private bool ballcame;
    public GameObject gate;

   

    private void OnCollisionEnter(Collision other) {
        
        if(other.gameObject.CompareTag("Player"))
        {
            ballcame = true;
        }

    }

    private void Update() {
        
        if(ballcame)
        {

            GetComponent<Animator>().SetTrigger("Pressed");
            gate.GetComponent<Animator>().SetTrigger("ButtonPressed");
           
        }
    }
}
