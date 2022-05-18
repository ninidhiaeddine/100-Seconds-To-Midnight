using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTracker : MonoBehaviour
{
    // parameter:
    public Text speedUI;
    public float speedFactor = 10.0f;

    // helper variable:
    private Vector3 oldPos;

    void Start()
    {
        oldPos = transform.position;
    }

    void FixedUpdate()
    {
        UpdateSpeedUI();
    }

    private void UpdateSpeedUI()
    {
        speedUI.text = FormatSpeed();
    }

    private string FormatSpeed()
    {
        return (GetSpeed() * speedFactor).ToString("F2") + " Km/h";
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
