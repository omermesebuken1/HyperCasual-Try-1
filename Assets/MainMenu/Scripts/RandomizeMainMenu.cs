using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeMainMenu : MonoBehaviour
{
    
    public GameObject[] Prefabs;
    private int i;
    private float RandomEuler1;
    private float RandomEuler2;
    private float RandomEuler3;
    
    private float RandomPos1;
    private float RandomPos2;
    private float RandomPos3;
    private float timer;
    public float timerCooldown;
    private Vector3 RandomVector;
    private float randomFallSpeed;
  


    private void Update() {


        timer += Time.deltaTime; 

        if(timer > timerCooldown)
        {

        i = Random.Range(0,Prefabs.Length-1);

        RandomEuler1 = Random.Range(0,360);
        RandomEuler2 = Random.Range(0,360);
        RandomEuler3 = Random.Range(0,360);

        RandomPos1 = Random.Range(-1,1);
        RandomPos2 = Random.Range(-1,1);
        RandomPos3 = Random.Range(-1,1);

        RandomVector = new Vector3(RandomPos1,RandomPos2,RandomPos3);


        GameObject clone = Instantiate(Prefabs[i],transform.position+RandomVector,Quaternion.Euler(RandomEuler1,RandomEuler2,RandomEuler3));

        Rigidbody rb = clone.GetComponent<Rigidbody>();

        randomFallSpeed = Random.Range(5,20);
        
        rb.AddForce(-transform.up*randomFallSpeed,ForceMode.Impulse);
    
        timer = 0;

        }










    }
    

}
