using UnityEngine;

public class HorizonBoundariesBehavior : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpaceshipPlayer"))
            SceneEndingManager.Instance.EndScene(sceneToLoad);
    }
}
