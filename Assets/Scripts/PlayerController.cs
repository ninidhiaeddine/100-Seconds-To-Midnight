using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float dy;
    private bool isRunning;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInput();
        UpdateAnimator();
    }

    void GetInput()
    {
        dy = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);
    }

    void UpdateAnimator()
    {
        anim.SetBool("IsRunning", isRunning);
        anim.SetFloat("Vertical", dy);
    }
}
