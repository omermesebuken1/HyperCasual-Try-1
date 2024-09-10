using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSound : MonoBehaviour
{
   [SerializeField] private AudioClip _clip;
   private float timer;

    private void Start() {

      GetComponent<AudioSource>().PlayOneShot(_clip);

    }

    private void Update() {
      timer += Time.deltaTime;

      if(timer > 2f || !FindObjectOfType<LaserTurret>().distanceOK || FindObjectOfType<PlayerDie>().playerDied)
      {
         Destroy(this.gameObject);
         timer = 0;
      }
    }
   

    
   
        
    

}
