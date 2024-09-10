using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    


    public Vector3 offset;
    public float smoothTime;
    public GameObject target;
    private Vector3 currentVelocity = Vector3.zero;

    private void Awake() {
        
        //offset = transform.position - target.transform.position;
    }


    private void FixedUpdate() {

        if(target != null)

        {
        
        if(target.transform.position.y > 0 && target.transform.position.y < 4 && target.transform.position.x < 4.7f && target.transform.position.x > -4.7f)
        {

        Vector3 TargetPosition = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position,TargetPosition,ref currentVelocity, smoothTime);

        }

        }

    }



}
