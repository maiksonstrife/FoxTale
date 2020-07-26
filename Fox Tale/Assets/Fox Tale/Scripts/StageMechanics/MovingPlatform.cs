using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public Transform platform;
    public float moveSpeed;
    public int currentPoint;



    // At the final point it goes to point 0 keep that in mind
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        //not exactly there but as it was actually there
        if(Vector3.Distance(platform.position, points[currentPoint].position) < 0.5f)
        {
            currentPoint++;

            if(currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
