using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{

     [Header("MOVE")]
    public Joystick joystick;
    public float Speed;
    private float inputX;
    private float inputY;
    private Vector3 currentVelocity = Vector3.zero;
    public float smoothBrake;
    private Rigidbody rb;
    public bool mobileOn;
    private bool temas;


    

    

    [Header("SHIELD")]

    public GameObject shield;
    public Joystick shieldjoystick;
    public GameObject shieldHealthSlider;
    
    private float shieldCurrentHealth;
    public float shieldMaxHealth;
    public float shieldRestoreCooldown;
    private float shieldRestorTimer;
    public float shieldRestoreSpeed;

    
    
    

   private void Awake() {

    rb = GetComponent<Rigidbody>();

   }

   private void Start() {

    shieldCurrentHealth = shieldMaxHealth;

   }

   private void Update() {
    
     BallFallen();
     ShieldHealth();
     showShieldHealth();
        
   }

    private void FixedUpdate() {

        Move();

    }

    private void Move()
    {

        if(mobileOn == false)
        {

        inputX = Input.GetAxis("Horizontal")*Speed*Time.deltaTime;
        inputY = Input.GetAxis("Vertical")*Speed*Time.deltaTime;

        }

        else

        {
            inputX = joystick.Horizontal*Speed*Time.deltaTime;
            inputY = joystick.Vertical*Speed*Time.deltaTime;
        }

        
    if(inputX != 0 || inputY != 0)
    {
        
        if(temas)
        {
                rb.velocity = new Vector3(inputX,0,inputY);
        }
        else
        {
                rb.velocity = new Vector3(inputX,-10f,inputY);
        }
        
        
        
        shield.transform.position = transform.position + new Vector3(0,-0.6f,0);
    }
        else
        {

        rb.velocity = Vector3.SmoothDamp(rb.velocity,Vector3.zero,ref currentVelocity, smoothBrake);
        }
    }

    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.CompareTag("Enemy"))
        {   
            temas = true;
            DestroyIt.Destructible destObj = GetComponent<DestroyIt.Destructible>();
            destObj.Destroy();

        }



    }

    private void OnCollisionStay(Collision other) 
    {
        temas = true;
    }

    private void OnCollisionExit(Collision other) {
        
        temas = false;
        
    }
    
    private void BallFallen()
    {
        if(transform.position.y < -1.6f)
        
        {
            DestroyIt.Destructible destObj = GetComponent<DestroyIt.Destructible>();
            destObj.Destroy();
        }
    }

    private void ShieldHealth()
    {

        if(shieldCurrentHealth > 0)
        {   

        if(shieldjoystick.Horizontal == 0 && shieldjoystick.Vertical == 0)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
            shieldCurrentHealth -= Time.deltaTime;
        }

        }
        else // shieldbroke
        {
            //shield.broke effect maybe
            shield.SetActive(false);
        }

        if(!shield.activeSelf && shieldCurrentHealth < shieldMaxHealth)
        {

            shieldRestorTimer += Time.deltaTime;

            if(shieldRestorTimer > shieldRestoreCooldown)
            {
            shieldCurrentHealth += shieldRestoreSpeed*Time.deltaTime;
            }
            


        }
        else
        {
            shieldRestorTimer = 0;
        }



    }

    private void showShieldHealth()
    {
        shieldHealthSlider.GetComponent<HealthBar>().SetMaxHealth(shieldMaxHealth);
        shieldHealthSlider.GetComponent<HealthBar>().SetHealth(shieldCurrentHealth);
    }



}
