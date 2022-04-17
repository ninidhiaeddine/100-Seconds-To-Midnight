using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipController : MonoBehaviour
{
    [Header("Forces Parameters")]
    [SerializeField] private float strafeForce;
    [SerializeField] private float thrustForce;
    [SerializeField] private float hoverForce;
    [SerializeField] private float pitchForce;
    [SerializeField] private float rollTorque;

    [Header("Reduction Parameters")]
    [SerializeField] [Range(0.01f, 0.99f)] private float thrustGlideReduction = 0.1f;
    [SerializeField] [Range(0.01f, 0.99f)] private float hoverGlideReduction = 0.1f;
    [SerializeField] [Range(0.01f, 0.99f)] private float strafeGlideReduction = 0.1f;

    // input values:
    private float strafeInput;
    private float thrustInput;
    private float hoverInput;
    private float rollInput;
    private float pitchInput;
    private float yawInput;

    // components:
    Rigidbody rb;

    // helper variables:
    private float thrustGlide = 0.0f;
    private float hoverGlide = 0.0f;
    private float strafeGlide = 0.0f;

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
        strafeInput = Input.GetAxis("Horizontal");
        thrustInput = Input.GetAxis("Vertical");
        hoverInput = Input.GetAxis("Hover");
        rollInput = Input.GetAxis("Roll");
        yawInput = Input.GetAxis("Mouse X");
        pitchInput = Input.GetAxis("Mouse Y");
    }

    void HandleMovement()
    {
        HandleThrust();
        HandleStrafe();
        HandlePitch();
        HandleRoll();
        HandleYaw();
        HandleHover();
    }

    void HandleHover()
    {
        if (Mathf.Abs(hoverInput) > 0.1f)
        {
            hoverGlide = hoverForce * hoverInput;
        }
        else
        {
            hoverGlide *= hoverGlideReduction;
        }
        rb.AddRelativeForce(Vector3.up * hoverGlide * Time.deltaTime);
    }

    void HandleThrust()
    {
        if (Mathf.Abs(thrustInput) > 0.1f)
        {
            thrustGlide = thrustForce * thrustInput;
        }
        else
        {
            thrustGlide *= thrustGlideReduction;
        }
        rb.AddRelativeForce(Vector3.forward * thrustGlide * Time.deltaTime);
    }

    void HandleStrafe()
    {
        if (Mathf.Abs(strafeInput) > 0.1f)
        {
            strafeGlide = Mathf.Clamp(Mathf.Abs(hoverGlide), 0.0f, 1.0f) * strafeInput * strafeForce;
        }
        else
        {
            strafeGlide *= strafeGlideReduction;
        }
        rb.AddRelativeForce(Vector3.right * strafeGlide * Time.deltaTime);
    }

    void HandlePitch()
    {
        if (Mathf.Abs(pitchInput) > 0.1f)
        {
            rb.AddRelativeTorque(
                Vector3.left 
                * Mathf.Clamp(pitchInput, -1f, 1f) 
                * pitchForce 
                * Mathf.Clamp(Mathf.Abs(thrustGlide), 0.0f, 1.0f) 
                * Time.deltaTime
                );
        }
    }

    void HandleYaw()
    {
        if (Mathf.Abs(yawInput) > 0.1f)
        {
            rb.AddRelativeTorque(
                Vector3.up 
                * Mathf.Clamp(yawInput, -1f, 1f) 
                * pitchForce 
                * Mathf.Clamp(Mathf.Abs(thrustGlide), 0.0f, 1.0f) 
                * Time.deltaTime
                );
        }
    }


    void HandleRoll()
    {
        if (Mathf.Abs(rollInput) > 0.1f)
        {
            rb.AddRelativeTorque(
                Vector3.back 
                * rollInput 
                * rollTorque 
                * Mathf.Clamp(Mathf.Abs(thrustGlide), 0.0f, 1.0f)
                * Time.deltaTime
                );
        }
    }
}
