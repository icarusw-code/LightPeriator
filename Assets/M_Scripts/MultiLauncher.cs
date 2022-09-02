using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiLauncher : MonoBehaviour
{
    public List<GameObject> laserPoints;

    PrismLaserChecker laserListener;

    void Start()
    {
        laserListener = GetComponent<PrismLaserChecker>();
    }

    void Update()
    {
        foreach (GameObject laser in laserPoints)
        {
            if (laserListener.isHit)
            {
                laser.SetActive(true);
            }
            else
            {
                laser.SetActive(false);
            }
        }
        
        laserListener.isHit = false;
    }

}
