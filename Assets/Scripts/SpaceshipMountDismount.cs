using UnityEngine;

public class SpaceshipMountDismount : MonoBehaviour
{
    public GameObject playerPrefab;
    public float distanceAwayFromSpaceshiptoDismount = 2.0f;
    public float distanceFromGroundToDismount = 2.0f;

    // helper variable:
    private bool isInSpaceship = false;

    // components:
    private ShipController shipController;
    private ShipShooter shipShooter;

    // children:
    private Transform spaceshipCanvasChild;
    private Transform spaceshipVCChild;

    private void Start()
    {
        shipController = GetComponent<ShipController>();
        shipShooter = GetComponent<ShipShooter>();
        spaceshipCanvasChild = transform.GetChild(0);
        spaceshipVCChild = transform.GetChild(1);
    }

    private void Update()
    {
        if (isInSpaceship && Input.GetKeyDown(KeyCode.F) && CloseToGround())
        {
            DismountSpaceship();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            MountSpaceship(other.gameObject);
        }
    }

    private void MountSpaceship(GameObject player)
    {
        ActivateScriptsAndComponents();
        Destroy(player);
        isInSpaceship = true;
    }

    private void DismountSpaceship()
    {
        DeactivateScriptsAndComponents();
        GameObject player = Instantiate(playerPrefab);

        // player position:
        Vector3 playerPos = Random.onUnitSphere * distanceAwayFromSpaceshiptoDismount + transform.position;
        player.transform.position = playerPos;

        isInSpaceship = false;
    }

    private void ActivateScriptsAndComponents()
    {
        shipController.enabled = true;
        shipShooter.enabled = true;
        spaceshipCanvasChild.gameObject.SetActive(true);
        spaceshipVCChild.gameObject.SetActive(true);
    }

    private void DeactivateScriptsAndComponents()
    {
        shipController.enabled = false;
        shipShooter.enabled = false;
        spaceshipCanvasChild.gameObject.SetActive(false);
        spaceshipVCChild.gameObject.SetActive(false);
    }

    private bool CloseToGround()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distanceFromGroundToDismount);
        foreach (Collider c in colliders)
        {
            if (c.CompareTag("Ground"))
                return true;
        }
        return false;
    }
}
