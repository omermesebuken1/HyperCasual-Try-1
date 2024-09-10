using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyer : MonoBehaviour
{
    private float timer;
        public GameObject destruction;
        [SerializeField] private AudioClip PlayerDiedSound;
        private bool dieSoundcast = false;

    private void Update() {

        

        if(destruction.GetComponent<PlayerDie>().playerDied)

        {

            
                
            if(!dieSoundcast)
            {
                GetComponent<AudioSource>().PlayOneShot(PlayerDiedSound);
                dieSoundcast = true;
            }
            

            timer += Time.deltaTime;
        }

        if(timer > 3)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    }

   

    
}
