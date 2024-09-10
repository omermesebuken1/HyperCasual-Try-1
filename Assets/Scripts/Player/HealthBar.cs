using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Image healthImage;
    private byte healthG;
    private byte healthOrani;

    private void Start() {

        healthImage.color = new Color32(255,255,60,255);
        
    }
    
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        if(health > slider.maxValue/4*3)
        {

                healthImage.color = new Color32(255,255,60,255);
        }

        if(health < slider.maxValue/4*3 && health > slider.maxValue/3)
        {

                healthImage.color = new Color32(255,200,60,255);
        }

        if (health < slider.maxValue/3)
        {

                healthImage.color = new Color32(255,60,60,255);

        }
        

    }

}
