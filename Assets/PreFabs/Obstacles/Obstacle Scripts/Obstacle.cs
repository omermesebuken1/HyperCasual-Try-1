using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public AudioClip Obstacle1;
    public AudioClip Obstacle2;
    public AudioClip Obstacle3;

    private float vol;
    private int r;

    public bool col;

    private float deleteYAmount = -10f;
    
    private AudioSource AS;

    private void Start() {
        AS = GetComponent<AudioSource>();
    }

    private void Update() {
        DeleteObject();
    }

   private void OnCollisionEnter(Collision other) {

    

    if(other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
    {

        col = true;

        r = Random.Range(1,3);

        if(r == 1)
        {
        vol = Random.Range(0.2f,0.4f);
        AS.PlayOneShot(Obstacle1,vol);
        }
        if(r == 2)
        {
        vol = Random.Range(0.2f,0.4f);
        AS.PlayOneShot(Obstacle2,vol);
        }
        if(r == 3)
        {
        vol = Random.Range(0.2f,0.4f);
        AS.PlayOneShot(Obstacle3,vol);
        }

    }
 

    

    
   }

   private void DeleteObject()
   {

    if(transform.position.y <= deleteYAmount)
    {
        Destroy(this.gameObject);
    }

   }

   
}
