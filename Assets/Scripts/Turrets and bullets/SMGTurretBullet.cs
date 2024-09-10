using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMGTurretBullet : MonoBehaviour
{
    public float bulletSpeed;

    public float bulletlife;

    private float bulletTimer;

    public GameObject anaTurret;
    private Rigidbody rb;
    public ParticleSystem hitEffect;

    public GameObject player;
     public Material shieldMetarial;

     


    [Header("SOUNDS")] 

    public AudioClip SMGShot;
    public AudioClip EnemyHitSound;
    
    
    public float SMGShotVOL;
    public float EnemyHitSoundVOL;
   

    private AudioSource ShotAudioSource;
    


   

    private void Awake() {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward*bulletSpeed);
        ShotAudioSource = GetComponent<AudioSource>();
        ShotAudioSource.PlayOneShot(SMGShot,SMGShotVOL);

    }


    private void OnCollisionEnter(Collision other) {
            
            if(other.gameObject.CompareTag("Shield"))
            {

               Instantiate(hitEffect,transform.position,transform.rotation);
               Destroy(this.gameObject);


            }

            if(other.gameObject.CompareTag("Player"))
            {
                ShotAudioSource.Stop();
                ShotAudioSource.PlayOneShot(EnemyHitSound,EnemyHitSoundVOL);

            }

            

            

            
        }
    
    private void Update()
    {

       
        bulletTimer += Time.deltaTime;
        

        if(bulletTimer>bulletlife)
        {
            Destroy(this.gameObject);
        }
        
    }
}
