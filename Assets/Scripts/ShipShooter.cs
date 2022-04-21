using UnityEngine;

public class ShipShooter : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform[] shootingPoints;
    [Range(100.0f, 5000.0f)]
    public float shootingForce = 3000.0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // compute position and rotation:
        Vector3 rocketPosition = PickRandomShootingPosition();
        Quaternion rocketRotation = Quaternion.Euler(
            90.0f + transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y, 
            0
            );
        // instantiate:
        GameObject rocket = Instantiate(rocketPrefab, rocketPosition, rocketRotation);

        // add force:
        Rigidbody rb = rocket.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * shootingForce, ForceMode.Acceleration);
    }

    // helper function:

    Vector3 PickRandomShootingPosition()
    {
        return this.shootingPoints[Random.Range(0, shootingPoints.Length)].position;
    }
}
