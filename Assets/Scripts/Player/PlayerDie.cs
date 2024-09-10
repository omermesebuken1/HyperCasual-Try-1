using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    
    
    public GameObject player;
    public bool playerDied;

    

    private void Update() {



        if(playerDied == false)
        {
        DestroyIt.Destructible destObj = player.GetComponent<DestroyIt.Destructible>();
    
            destObj.FireDestroyedEvent();
            
            if(destObj.IsDestroyed)
            {
                playerDied = true;
                FindObjectOfType<CameraShake>().CameraShakeCall();

            }
                
        }

            

            

            


    }

}
