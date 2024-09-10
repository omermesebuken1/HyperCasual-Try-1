using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : MonoBehaviour
{
    public LayerMask player_layer;
    public LayerMask shield_layer;
    public LayerMask obstacle_layer;
    RaycastHit hitObstacle;
    RaycastHit hitShield;
    RaycastHit hitPlayer;
    
    public GameObject target;

    public GameObject childrenTurret;
    public GameObject turretTaban;
    public float tabanDonmeHizi;


    private float timer = 0f;
    public float laserCooldown;

    public GameObject bulletPoint;
    public bool fire;

    public bool distanceOK;
    private float distance;

    private Vector3 distanceVector;
    private Vector3 lookPosition;

    private Vector3 randomForceVector;
    public float forceMagnitude;
   

    public GameObject hitSound;
    public GameObject girisSound;

    private bool hitSoundOn = false;
    private bool girisSoundOn = false;

    private Vector3 distanceToObstacleVector;
    private Vector3 distanceToShieldVector;
    private Vector3 distanceToPlayerVector;

    private float distanceToObstacle;
    private float distanceToShield;
    private float distanceToPlayer;

    private bool rayCast;

    private bool thereIsObstacle;
    private bool thereIsShield;
    private bool thereIsPlayer;




    private void Update()
    {


        if (FindObjectOfType<PlayerEnter>().isEnter && target != null)
        {


            
            DistanceChecker();
            TurretLook();
            tabandonme();
            


        }

    }



    private void TurretLook() // bakma
    {

        if (distanceOK && fire)
        {


            lookPosition = target.transform.position;
            lookPosition.y = childrenTurret.transform.position.y;

            childrenTurret.transform.LookAt(lookPosition);
            childrenTurret.transform.rotation *= Quaternion.Euler(-90, 0, 0);

            Debug.DrawRay(bulletPoint.transform.position, -bulletPoint.transform.up * 100, Color.green);
            



            timer += Time.deltaTime;

            if (timer <= laserCooldown)
            {

                
                GetComponent<LineRenderer>().startWidth = 0f;

            }
            if (timer > 0.9f && !girisSoundOn)
            {

               
                
                Instantiate(girisSound);
                girisSoundOn = true;
            }

            if (timer > laserCooldown && timer <= laserCooldown * 3 / 2)
            {


                if (!hitSoundOn)
                {
                    Instantiate(hitSound);
                    hitSoundOn = true;
                }
                rayCast = true;
                DrawRaycast();
                DrawLaser();
                
            }

            if (timer > laserCooldown * 3 / 2)
            {
                rayCast = false;
                timer = 0;
                hitSoundOn = false;
                girisSoundOn = false;


            }


        }
        else
        {
            timer = 0;
            hitSoundOn = false;
            girisSoundOn = false;
            
            GetComponent<LineRenderer>().startWidth = 0f;

            

        }
    }



    private void DistanceChecker()
    {
        distanceVector.x = transform.position.x - target.transform.position.x;
        distanceVector.z = transform.position.z - target.transform.position.z;

        distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.z, 2));


        if (distance < 25)
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
        if (distanceOK)
        {
            turretTaban.transform.rotation *= Quaternion.Euler(0, 0, tabanDonmeHizi * Time.deltaTime);
        }
    }

    private void DrawRaycast()
    {


        if (Physics.Raycast(bulletPoint.transform.position, -bulletPoint.transform.up, out hitObstacle, 250f, obstacle_layer) && fire)
        {
            thereIsObstacle = true;
            if(rayCast && target != null && hitObstacle.transform != null) 
        {

        distanceToObstacleVector.x = transform.position.x - hitObstacle.transform.position.x;
        distanceToObstacleVector.z = transform.position.z - hitObstacle.transform.position.z;

        distanceToObstacle = Mathf.Sqrt(Mathf.Pow(distanceToObstacleVector.x, 2) + Mathf.Pow(distanceToObstacleVector.z, 2));
    
        }

        }
        else
        {
            thereIsObstacle = false;
        }






        if (Physics.Raycast(bulletPoint.transform.position, -bulletPoint.transform.up, out hitShield, 250f, shield_layer) && fire)
        {

            thereIsShield = true;

            if(rayCast && target != null && hitShield.transform != null) 
        {

        distanceToShieldVector.x = transform.position.x - hitShield.transform.position.x;
        distanceToShieldVector.z = transform.position.z - hitShield.transform.position.z;

        distanceToShield = Mathf.Sqrt(Mathf.Pow(distanceToShieldVector.x, 2) + Mathf.Pow(distanceToShieldVector.z, 2));
        //print(distanceToShield);


        }

        }
        else
        {
            thereIsShield = false;
        }
        






       if (Physics.Raycast(bulletPoint.transform.position, -bulletPoint.transform.up, out hitPlayer, distance, player_layer) && fire)
        {

            thereIsPlayer = true;
            if(rayCast && target != null && hitPlayer.transform != null) 
        {

        distanceToPlayerVector.x = transform.position.x - hitPlayer.transform.position.x;
        distanceToPlayerVector.z = transform.position.z - hitPlayer.transform.position.z;

        distanceToPlayer = Mathf.Sqrt(Mathf.Pow(distanceToPlayerVector.x, 2) + Mathf.Pow(distanceToPlayerVector.z, 2));
        //print(distanceToPlayer);


        }

        }
        else
        {
            thereIsPlayer = false;
        }

        

       

    }

   

   
    private void DrawLaser()
        {

            if((distanceToObstacle < distanceToShield || distanceToObstacle < distanceToPlayer) && thereIsObstacle)
            {
                //draw ray to obs
            GetComponent<LineRenderer>().SetPosition(0, bulletPoint.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hitObstacle.point);
            GetComponent<LineRenderer>().startWidth = 0.1f;

            Rigidbody obsrb = hitObstacle.transform.gameObject.GetComponent<Rigidbody>();
            randomForceVector = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2), Random.Range(-1, 1));
            obsrb.AddForce((-hitObstacle.transform.forward + randomForceVector) * forceMagnitude, ForceMode.Impulse);

            }
            else if(distanceToShield < distanceToPlayer && thereIsShield)
            {
                //draw ray to shield
            GetComponent<LineRenderer>().SetPosition(0, bulletPoint.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hitShield.point);
            GetComponent<LineRenderer>().startWidth = 0.1f;

            }
            else if(distanceToPlayer <= 25 && thereIsPlayer)
            {
                //draw ray to player
            GetComponent<LineRenderer>().SetPosition(0, bulletPoint.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hitPlayer.point);
            GetComponent<LineRenderer>().startWidth = 0.1f;

            DestroyIt.Destructible destObj = target.GetComponent<DestroyIt.Destructible>();
            destObj.Destroy();

            }
            else
            {
                //dont Draw
                GetComponent<LineRenderer>().startWidth = 0f;
            }
            
        }
    





}

