using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    


    public IEnumerator CameraShakes(float duration, float magnitude)
    {

        

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f,1f) * magnitude;   
            float y = Random.Range(-1f,1f) * magnitude;   

            transform.localPosition += new Vector3(x,y,0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        

        

    }

    public void CameraShakeCall()
    {
        StartCoroutine(CameraShakes(0.2f,0.1f));
    }
}
