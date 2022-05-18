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

    // input values:
    private float strafeInput;
    private float thrustInput;
    private float hoverInput;
    private float rollInput;
    private float pitchInput;
    private float yawInput;

    // components:
    Rigidbody rb;

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
            rb.AddRelativeForce(Vector3.up * hoverForce * hoverInput * Time.deltaTime);
        }
    }

    void HandleThrust()
    {
        if (Mathf.Abs(thrustInput) > 0.1f)
        {
            rb.AddRelativeForce(Vector3.forward * thrustForce * thrustInput * Time.deltaTime);
        }
    }

    void HandleStrafe()
    {
        if (Mathf.Abs(strafeInput) > 0.1f)
        {
            rb.AddRelativeForce(
                Vector3.right 
                * Mathf.Abs(hoverInput)
                * strafeInput 
                * strafeForce 
                * Time.deltaTime);
        }
    }

    void HandlePitch()
    {
        if (Mathf.Abs(pitchInput) > 0.1f)
        {
            rb.AddRelativeTorque(
                Vector3.left 
                * Mathf.Clamp(pitchInput, -1.0f, 1.0f) 
                * pitchForce 
                * Mathf.Abs(thrustInput)
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
                * Mathf.Clamp(yawInput, -1.0f, 1.0f) 
                * pitchForce 
                * Mathf.Abs(thrustInput) 
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
                * Time.deltaTime
                );
        }
    }
}
