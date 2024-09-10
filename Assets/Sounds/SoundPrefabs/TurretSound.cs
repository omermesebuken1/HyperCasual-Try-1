using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSound : MonoBehaviour
{
   
    [SerializeField] private AudioClip _clip;
   private float timer;

    private void Start() {

      GetComponent<AudioSource>().PlayOneShot(_clip);

    }

    private void Update() {
      timer += Time.deltaTime;

      if(timer > 1f)
      {
         Destroy(this.gameObject);
      }
    }

}
