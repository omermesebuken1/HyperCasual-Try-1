using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsSceneStars : MonoBehaviour
{
    [SerializeField] private int level;

    [SerializeField] private Sprite[] Images;
    
    private int stars;

    private void Update() {

        
         

        if(PlayerPrefs.HasKey("Level_" + level.ToString() + "_Stars"))
        {

           stars = PlayerPrefs.GetInt("Level_" + level.ToString() + "_Stars");


           if(stars == 3)
           {
                GetComponent<Image>().color = new Color(1,1,1,1);
                GetComponent<Image>().sprite = Images[0];
                GetComponent<Image>().SetNativeSize();
           }
           else if(stars == 2)
           {
                GetComponent<Image>().color = new Color(1,1,1,1);
                GetComponent<Image>().sprite = Images[1];
                GetComponent<Image>().SetNativeSize();
           }
           else if(stars == 1)
           {
                GetComponent<Image>().color = new Color(1,1,1,1);
                GetComponent<Image>().sprite = Images[2];
                GetComponent<Image>().SetNativeSize();
           }
           else if(stars == 0)
           {
                
                GetComponent<Image>().color = new Color(1,1,1,0);
                
           }
           else 
           {
                GetComponent<Image>().color = new Color(1,1,1,0);
           }

           
            

        }

        else
        {

            GetComponent<Image>().color = new Color(1,1,1,0);

        }

    }

}
