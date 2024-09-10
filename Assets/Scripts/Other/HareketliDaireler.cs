using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketliDaireler : MonoBehaviour
{
    
    public GameObject bridge;
    

    private void Update() {

        if(bridge.GetComponent<PlayerEnter>().isEnter)
        {

            GetComponent<Animator>().SetTrigger("Calis");
            

        }
    }
}
