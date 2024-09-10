using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScaleChange : MonoBehaviour
{
    [Header("Scale")]

    [SerializeField] private bool scale;

    [SerializeField] private bool ScaleX;
    [SerializeField] private bool ScaleY;
    [SerializeField] private bool ScaleZ;

    [SerializeField] private float ScaleSpeed;

    [SerializeField] private float MinScaleAmount;
    [SerializeField] private float MaxScaleAmount;

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


    private bool scaleUp;
    

    private bool col = false;

    private void Start() {

        rb = GetComponent<Rigidbody>();

        MaxX = transform.localScale.x*MaxScaleAmount;
        MaxY = transform.localScale.y*MaxScaleAmount;
        MaxZ = transform.localScale.z*MaxScaleAmount;

        MinX = transform.localScale.x*MinScaleAmount;
        MinY = transform.localScale.y*MinScaleAmount;
        MinZ = transform.localScale.z*MinScaleAmount;

        //Which axis to rotate

        if(ScaleX == true)
        {
            x = 1;
        }
        else
        {
            x = 0;
        }

        if(ScaleY == true)
        {
            y = 1;
        }
        else
        {
            y = 0;
        }

        if(ScaleZ == true)
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
            

            if(scale)
            {

            //rb.useGravity = false;

                if(transform.localScale.x >= MaxX && transform.localScale.y >= MaxY && transform.localScale.z >= MaxZ)
                {
                    scaleUp = false;
                }

                if(transform.localScale.x <= MinX && transform.localScale.y <= MinY && transform.localScale.z <= MinZ)
                {
                    scaleUp = true;
                }



                if(scaleUp)
                {
                    transform.localScale += new Vector3(x,y,z)*ScaleSpeed;
                }
                else
                {
                    transform.localScale -= new Vector3(x,y,z)*ScaleSpeed;
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
