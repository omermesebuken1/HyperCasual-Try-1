using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
   
   public LayerMask player_layer;
   RaycastHit hit;
   public Transform target;
   
    public GameObject childrenTurret;
    public GameObject turretTaban;
    public float tabanDonmeHizi;




   public float bulletCooldown;
   public GameObject bullet;
   private float timer = 0f;
   public GameObject bulletPoint;
   public bool fire;
   private bool distanceOK;
   private float distance;

   private Vector3 distanceVector;
   private Vector3 lookPosition;

   public GameObject turretSound;
   
   

   private void Update() {

    if(FindObjectOfType<PlayerEnter>().isEnter && target != null)
    {

    

    DistanceChecker();
    TurretLook();
    TurretShot();
    tabandonme();

    }

   }



   private void TurretLook() // bakma
   {

    if(distanceOK)
    {
    Debug.DrawRay(transform.position,-transform.forward*100,Color.green);
    drawLineToTarget();
    
    //if(Physics.Raycast(transform.position,-transform.up,out hit,Mathf.Infinity,player_layer))
    //{
    //}
    
    lookPosition = target.position;
    lookPosition.y = childrenTurret.transform.position.y;

    childrenTurret.transform.LookAt(lookPosition);
    childrenTurret.transform.rotation *= Quaternion.Euler(-90,0,0); 
    //transform.LookAt(target);
    //transform.rotation *= Quaternion.Euler(0,180,0); 
    }
    else
    {
        deleteLine();
    }
   }

   private void TurretShot() // ateş etme
   {

    if(timer >= bulletCooldown && fire && distanceOK)
    {

        Instantiate(turretSound);
        Instantiate(bullet,bulletPoint.transform.position,childrenTurret.transform.rotation*Quaternion.Euler(-90,0,0));
        timer = 0;


    }
    else
    {
        timer += Time.deltaTime;
    }

    

   }

   private void DistanceChecker()
    {
        distanceVector.x = transform.position.x - target.position.x;
        distanceVector.z = transform.position.z - target.position.z;

        distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x,2) + Mathf.Pow(distanceVector.z,2));

        
        if(distance < 25)
        {
            distanceOK = true;
        }
        else
        {
            distanceOK = false;
        }

    }

    private void tabandonme()
    {
        if(distanceOK)
        {
        turretTaban.transform.rotation *= Quaternion.Euler(0,0,tabanDonmeHizi*Time.deltaTime);
        }
    }

    private void drawLineToTarget()
    {
                GetComponent<LineRenderer>().SetPosition(0, bulletPoint.transform.position);
                GetComponent<LineRenderer>().SetPosition(1, target.transform.position);
                GetComponent<LineRenderer>().startWidth = 0.03f;
    }

    private void deleteLine()
    {
                GetComponent<LineRenderer>().startWidth = 0;
    }
}
