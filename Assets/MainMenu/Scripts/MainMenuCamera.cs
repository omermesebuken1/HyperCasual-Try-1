using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public GameObject target;
    public float speed;
    
    void Update()
    {

        transform.RotateAround(target.transform.position,new Vector3(0,1,0),speed*Time.deltaTime);
        
        
    }
}
