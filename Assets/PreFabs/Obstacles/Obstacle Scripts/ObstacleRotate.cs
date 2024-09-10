using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{

    
    [Header("Rotate")]

    [SerializeField] private bool Rotate;

    [SerializeField] private bool Rx;
    [SerializeField] private bool Ry;
    [SerializeField] private bool Rz;

    [SerializeField] private float RotateSpeed;

    private float x;
    private float y;
    private float z;

    private Rigidbody rb;


    private bool col = false;

    private void Start() {

        rb = GetComponent<Rigidbody>();
    }
    
    private void Update() {

        //Which axis to rotate

        if(Rx == true)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if(Ry == true)
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if(Rz == true)
        {
            z = 1;
        }
        else
        {
            z = 0;
        }



        //Rotate until collision

        if(col)
        {
            //do nothing
            rb.useGravity = true;
        }
        else
        {
            if(Rotate)
            {
            rb.useGravity = false;
            transform.Rotate(x*RotateSpeed,y*RotateSpeed,z*RotateSpeed);
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
