using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleJump : MonoBehaviour
{
    
    [Header("Jump")]

    [SerializeField] private bool jump;

    [SerializeField] private float JumpAmount;

    [SerializeField] private bool jx;
    [SerializeField] private bool jy;
    [SerializeField] private bool jz;

    [SerializeField] private float timerCooldown;

    private float timer;

    private float x;
    private float y;
    private float z;


    private Rigidbody rb;

    

    


    private bool col = false;

    private void Start() {

        rb = GetComponent<Rigidbody>();
        rb.useGravity = true; 
        if(jx == true)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if(jy == true)
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if(jz == true)
        {
            z = 1;
        }
        else
        {
            z = 0;
        }

    }
    
    private void Update() {

       timer += Time.deltaTime;

        //Rotate until collision

        if(col)
        {
            //do nothing
           
        }
        else
        {
            if(jump)
            {

            
            if(timer>timerCooldown)
            {
            
                  
            rb.AddForce(new Vector3(x,y,z)*JumpAmount);
            timer = 0;

            }
            
            }

        }
        
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Obstacle") || other.gameObject.CompareTag("Enemy"))
        {
            col = true;
        }

    }
     }

  
