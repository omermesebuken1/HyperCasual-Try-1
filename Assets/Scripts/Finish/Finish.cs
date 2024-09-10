using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    public AudioClip endsound;
    public bool ended;
    public GameObject endbox;
    public ParticleSystem finishEffect;

    private void Start() {
        
        endbox.SetActive(false);
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player") && !ended)
        {

            GetComponent<AudioSource>().PlayOneShot(endsound);
            ended = true;
            endbox.SetActive(true);
            Instantiate(finishEffect,transform.position,transform.rotation);
            

        }
    }
}
