using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEntry : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceshipPlayer"))
        {
            SceneEndingManager.Instance.EndScene(sceneToLoad);            
        }
    }
}
