using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTurretSecondLineRenderer : MonoBehaviour
{
    public GameObject anaLaserTurret;
    

    void Update()
    {

        if(anaLaserTurret.GetComponent<LaserTurret>().distanceOK && 
           anaLaserTurret.GetComponent<LaserTurret>().fire &&  
           anaLaserTurret.GetComponent<LaserTurret>().target != null )
        {
            drawLineToTarget();

        }
        else
        {
            deleteLine();
        }
        
    }

    private void drawLineToTarget()
    {
                GetComponent<LineRenderer>().SetPosition(0, transform.position);
                GetComponent<LineRenderer>().SetPosition(1, anaLaserTurret.GetComponent<LaserTurret>().target.transform.position);
                GetComponent<LineRenderer>().startWidth = 0.003f;
    }

    private void deleteLine()
    {
                GetComponent<LineRenderer>().startWidth = 0;
    }


}
