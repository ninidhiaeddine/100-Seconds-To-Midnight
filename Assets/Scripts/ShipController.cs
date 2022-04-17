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
    private float mouseX;
    private flota mouseY;

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
        dy = Input.GetAxisRaw("Hover");
        dz = Input.GetAxisRaw("Vertical");
    }

    void HandleMovement()
    {
        HandleThrust();
        //HandleStrafe();
        //HandlePitch();
        HandleHover();
    }

    void HandleStrafe()
    {
        if (Mathf.Abs(dx) > 0.1f)
        {
            rb.AddRelativeForce(Vector3.right * strafeForce * dx * Time.deltaTime);
        }
    }

    void HandlePitch()
    {
        if (Mathf.Abs(dx) > 0.1f)
        {
            rb.AddRelativeTorque(Vector3.back * strafeForce * dx * Time.deltaTime);
        }
    }

    void HandleHover()
    {
        if (Mathf.Abs(dy) > 0.1f)
        {
            rb.AddRelativeForce(Vector3.up * hoverForce * dy * Time.deltaTime);
        }
    }

    void HandleThrust()
    {
        if (Mathf.Abs(dz) > 0.1f)
        {
            rb.AddRelativeForce(Vector3.forward * thrustForce * dz * Time.deltaTime);
        }
    }
}
