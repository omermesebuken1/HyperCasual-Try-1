using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    
    public float zOffset;
    private bool spawned;
    public GameObject Level;
    
    

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("Player") && !spawned)
        {
            Instantiate(Level,Level.transform.position+new Vector3(0,0,zOffset),Quaternion.identity);
            spawned = true;
        }

    }

    
}
