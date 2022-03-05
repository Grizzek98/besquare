using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    [Range(1, 10)] 
    public float smoothFactor;

    public float timer = 2;
    public bool startTracking = false;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            startTracking = true;
        }
    }

    void FixedUpdate()
    {
        if (startTracking)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.smoothDeltaTime);
        transform.position = smoothPosition;

    }
}
