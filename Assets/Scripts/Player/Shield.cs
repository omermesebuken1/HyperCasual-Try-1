using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{


    

    public Joystick joystick;
    private float ShieldinputX;
    private float ShieldinputY;
    private Vector3 shieldOr;
    private Vector3 lookpos;
   




    private Vector3 shieldOffset;


    public GameObject shildHitSound;

    private void Start() {

        shieldOffset = new Vector3(-90f,90f,0);
    }

    private void Update()
    {
        
        

        RotateShield();

        


    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {

            GetComponent<Animator>().SetTrigger("hit");
           Instantiate(shildHitSound);




        }

    }

  

    

    private void RotateShield()
    {

        

        ShieldinputX = joystick.Horizontal;
        ShieldinputY = joystick.Vertical;

        shieldOr = new Vector3(ShieldinputX,0,ShieldinputY);


        lookpos.x = transform.position.x + shieldOr.x;
        lookpos.y = transform.position.y + shieldOr.y;
        lookpos.z = transform.position.z + shieldOr.z;
    

        if(ShieldinputX != 0 || ShieldinputY != 0)
        {
        transform.LookAt(lookpos);
        transform.rotation *= Quaternion.Euler(shieldOffset);
        }
        
        
    }
        
        


    }
