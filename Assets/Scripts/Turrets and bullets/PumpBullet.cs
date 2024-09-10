using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpBullet : MonoBehaviour
{
    public float bulletSpeed;

    private float bulletlife = 0.5f;

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

            

            
        }
    
    private void Update()
    {
        
        if(bulletTimer>bulletlife/5)
        {
        rb.velocity = new Vector3(0,0,0);
        Destroy(this.gameObject);

        }

        bulletTimer += Time.deltaTime;
        

        if(bulletTimer>bulletlife / 2 )
        {
            Destroy(this.gameObject);
        }
        
    }
}
