using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTracker : MonoBehaviour
{
    // parameter:
    public bool printSpeed = true;
    public float speedFactor = 10.0f;

    // helper variable:
    private Vector3 oldPos;

    void Start()
    {
        oldPos = transform.position;
    }

    void FixedUpdate()
    {
        if (printSpeed)
            PrintSpeed();
    }

    void PrintSpeed()
    {
        Debug.Log("Speed: " + (GetSpeed() * speedFactor).ToString("F2") + " km/h");
    }

    public float GetSpeed()
    {
        float distance = Vector3.Distance(oldPos, transform.position);
        float speed = distance / Time.fixedDeltaTime;

        // update old position:
        oldPos = transform.position;

        return speed;
    }
}
