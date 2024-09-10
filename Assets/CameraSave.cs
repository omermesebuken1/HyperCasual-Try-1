using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("CameraPosX"))
        {
            float cameraPosX = PlayerPrefs.GetFloat("CameraPosX");
            float cameraPosY = PlayerPrefs.GetFloat("CameraPosY");
            float cameraPosZ = PlayerPrefs.GetFloat("CameraPosZ");
            
            transform.position = new Vector3(cameraPosX,cameraPosY,cameraPosZ);
        }
        
        
    }

    
    public void SaveCameraPos()
    {

        PlayerPrefs.SetFloat("CameraPosX",transform.position.x);
        PlayerPrefs.SetFloat("CameraPosY",transform.position.y);
        PlayerPrefs.SetFloat("CameraPosZ",transform.position.z);

    }
}
