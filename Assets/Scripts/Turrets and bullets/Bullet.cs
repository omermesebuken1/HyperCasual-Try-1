using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    private float bulletlife = 4f;

    private float bulletTimer;

    public GameObject anaTurret;
    private Rigidbody rb;
    public ParticleSystem hitEffect;

    public GameObject player;


    

    public Material shieldMetarial;

    private void Awake() {

        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward*bulletSpeed);

    }


    private void OnCollisionEnter(Collision other) {
            
            if(other.gameObject.CompareTag("Shield"))
            {

               Instantiate(hitEffect,transform.position,transform.rotation);
               Destroy(this.gameObject);


            }

            if(other.gameObject.CompareTag("Player"))
            {

               
               Destroy(this.gameObject);


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
