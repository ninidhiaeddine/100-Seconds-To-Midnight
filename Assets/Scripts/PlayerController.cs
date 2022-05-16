using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // paramters:
    [Range(1.0f, 3.0f)] public float walkingSpeed = 1.5f;
    [Range(2.0f, 5.0f)] public float runningSpeed = 3.5f;
    [Range(50.0f, 200.0f)] public float rotationSpeed = 100.0f;
    public float gravityForce = -9.81f;

    // input:
    private float dx;
    private float dy;
    private bool isRunning;

    // components:
    private Animator anim;
    private CharacterController characterController;

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        GetInput();
        HandleMovement();
        HandleRotation();
        SetAnimation();
        ApplyGravity();
    }

    void GetInput()
    {
        dx = Input.GetAxis("Horizontal");
        dy = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    void HandleMovement()
    {
        Vector3 motion;
        if (!isRunning)
            motion = dy * transform.forward * walkingSpeed * Time.deltaTime;
        else
            motion = dy * transform.forward * runningSpeed * Time.deltaTime;
        
        // apply motion:
        characterController.Move(motion);
    }

    void HandleRotation()
    {
        transform.Rotate(transform.up, dx * rotationSpeed * Time.deltaTime);
    }

    void SetAnimation()
    {
        anim.SetBool("IsRunning", isRunning);
        anim.SetFloat("Vertical", dy);
    }
    
    void ApplyGravity()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(Vector3.up * gravityForce * Time.deltaTime);
        }
    }
}
