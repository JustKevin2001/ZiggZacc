using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Attributes
    [SerializeField] Transform target;
    [SerializeField] float smoothValue;

    // Distance between our obj and cam => Like offset
    private Vector3 distance;

    void Start()
    {
        // Offset
        distance = target.position - transform.position;
    }

    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }
    }

    private void Follow()
    {
        Vector3 currentPos = transform.position; 

        Vector3 targetPos = target.position - distance;

        // Make the camera go smoothly from the cam pos to target pos
        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValue * Time.deltaTime);   

    }
}


// CLipping Planes => Obj da bi camera di qua se bi clip
// Car fall down => Cam khong follow => Platform top spawning