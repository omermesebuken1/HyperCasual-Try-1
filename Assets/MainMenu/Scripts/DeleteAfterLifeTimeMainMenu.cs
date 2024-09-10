using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterLifeTimeMainMenu : MonoBehaviour
{
   private float timer;
   private float lifetime = 15f;

   private void Update() {

    timer += Time.deltaTime;

    if(timer > lifetime)
    {
        Destroy(this.gameObject);
    }
   }
}
