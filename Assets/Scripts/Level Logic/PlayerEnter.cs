using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public bool isEnter = false;
    public GameObject gate;
    
    private void OnTriggerEnter(Collider other) {

        if(other.gameObject.CompareTag("Player"))

        {

        gate.GetComponent<Animator>().SetTrigger("Entered");
        isEnter = true;

        }

    }

}
