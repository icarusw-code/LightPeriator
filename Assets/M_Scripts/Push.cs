using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Push : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    List<int> handPoints = new List<int>() {-1, -1, -1, -1, -1, -1, -1, -1, -1, -1};

    public bool isPush = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (udpReceive.data.Length == 0) return;
        else
        {
            string data = udpReceive.data;
            data = data.Remove(0, 1);
            data = data.Remove(data.Length - 1, 1);

            string[] points = data.Split(',');

            if (handPoints[0] < 0)
            {
                handPoints[0] = int.Parse(points[0]);
                handPoints[1] = int.Parse(points[25]);
                handPoints[2] = int.Parse(points[37]);
                handPoints[3] = int.Parse(points[49]);
                handPoints[4] = int.Parse(points[61]);
            }
            else
            {
                handPoints[5] = int.Parse(points[0]);
                handPoints[6] = int.Parse(points[25]);
                handPoints[7] = int.Parse(points[37]);
                handPoints[8] = int.Parse(points[49]);
                handPoints[9] = int.Parse(points[61]);
            }

            if (handPoints[5] - handPoints[0] > 100)
            {
                isPush = true;
                List<int> handPoints = new List<int>() { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
            }
            else
            {
                isPush = false;
            }
        }
    }
}