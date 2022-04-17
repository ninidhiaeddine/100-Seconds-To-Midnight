using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    // input values:
    private float dx;
    private float dy;
    private float dz;

    // components:
    Rigidbody rb;

    // parameters:
    public float strafeForce;
    public float thrustForce;
    public float hoverForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        GetInput();
        HandleMovement();
    }

    void GetInput()
    {
        dx = Input.GetAxisRaw("Horizontal");
        dy = Input.GetAxisRaw("Vertical");
        //dz = Input.GetAxisRaw("Hover");
    }

    void HandleMovement()
    {
        HandleThrust();
        
    }

    void HandleThrust()
    {
        if (Mathf.Abs(dy) > 0.1f)
        {
            rb.AddRelativeForce(Vector3.forward * thrustForce * dy * Time.deltaTime);
        }
    }
}
