using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f; 
    private Vector3 offset = new Vector3(2,0,0);
    public int minX;
    public int maxX;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            smoothedPosition.y = transform.position.y;
            smoothedPosition.z = transform.position.z;

            if (smoothedPosition.x < minX)
            {
                smoothedPosition.x = minX;
            }
            if (smoothedPosition.x > maxX)
            {
                smoothedPosition.x = maxX;
            }

            transform.position = smoothedPosition;


        }
    }
}
