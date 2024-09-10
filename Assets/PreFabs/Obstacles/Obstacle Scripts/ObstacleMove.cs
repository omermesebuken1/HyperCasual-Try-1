using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
   [Header("Move")]

    [SerializeField] private bool move;

    [SerializeField] private bool MoveX;
    [SerializeField] private bool MoveY;
    [SerializeField] private bool MoveZ;

    [SerializeField] private float MoveSpeed;

    [SerializeField] private float MoveAmount;


    private float x;
    private float y;
    private float z;


    private float MaxX;
    private float MaxY;
    private float MaxZ;

    private float MinX;
    private float MinY;
    private float MinZ;


    private Rigidbody rb;


    private bool MoveUp;
    

    private bool col = false;

    private void Start() {

        rb = GetComponent<Rigidbody>();

        MaxX = transform.position.x+MoveAmount;
        MaxY = transform.position.y+MoveAmount;
        MaxZ = transform.position.z+MoveAmount;

        MinX = transform.position.x-MoveAmount;
        MinY = transform.position.y-MoveAmount;
        MinZ = transform.position.z-MoveAmount;

        


        //Which axis to rotate

        if(MoveX == true)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if(MoveY == true)
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if(MoveZ == true)
        {
            z = 1;
        }
        else
        {
            z = 0;
        }

        

    }
    
    private void Update() {

        //Rotate until collision

        if(col)
        {
            //do nothing
            rb.useGravity = true;
        }

        else
        {
            

            if(move)
            {

            rb.useGravity = false;

                if(transform.position.x >= MaxX || transform.position.y >= MaxY || transform.position.z >= MaxZ)
                {
                    MoveUp = false;
                }

                if(transform.position.x <= MinX || transform.position.y <= MinY || transform.position.z <= MinZ)
                {
                    MoveUp = true;
                }



                if(MoveUp)
                {
                    transform.position += new Vector3(x,y,z)*MoveSpeed;
                }
                else
                {
                    transform.position -= new Vector3(x,y,z)*MoveSpeed;
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
