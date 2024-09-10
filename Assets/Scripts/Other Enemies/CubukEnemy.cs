using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubukEnemy : MonoBehaviour
{
    
    public float rotateSpeed;


    private void Update() {

        transform.rotation *= Quaternion.Euler(0,0,rotateSpeed*Time.deltaTime);

    }
}
