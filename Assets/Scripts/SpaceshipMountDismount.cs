using UnityEngine;
using System.Collections;

public class SpaceshipMountDismount : MonoBehaviour
{
    [Header("Parameters")]
    public GameObject playerPrefab;
    public float distanceAwayFromSpaceshiptoDismount = 2.0f;
    public float distanceFromGroundToDismount = 2.0f;
    public float delayToDismount;

    [Header("Reference To Children")]
    public Transform spaceshipCanvasChild;
    public Transform spaceshipVCChild;

    // helper variable:
    public bool isInSpaceship = false;
    private bool canDismount = false;

    // components:
    private ShipController shipController;
    private ShipShooter shipShooter;
    

    private void Start()
    {
        shipController = GetComponent<ShipController>();
        shipShooter = GetComponent<ShipShooter>();
    }

    private void Update()
    {
        if (isInSpaceship && Input.GetKeyDown(KeyCode.F) && CloseToGround() && canDismount)
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
        StartCoroutine(CanDismountAfterDelay());

        // update global player reference:
        PlayerReferenceTracker.Instance.globalPlayerReference = this.transform;
    }

    private IEnumerator CanDismountAfterDelay()
    {
        yield return new WaitForSeconds(delayToDismount);
        canDismount = true;
    }

    private void DismountSpaceship()
    {
        DeactivateScriptsAndComponents();
        GameObject player = Instantiate(playerPrefab);

        // player position:
        Vector3 playerPos = Random.onUnitSphere * distanceAwayFromSpaceshiptoDismount + transform.position;
        player.transform.position = playerPos;

        canDismount = false;
        isInSpaceship = false;

        // update global player reference:
        PlayerReferenceTracker.Instance.globalPlayerReference = player.transform;
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
