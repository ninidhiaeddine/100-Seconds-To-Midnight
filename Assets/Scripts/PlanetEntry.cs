using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEntry : MonoBehaviour
{
    public string sceneNameToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneEndingManager.Instance.sceneNameToLoad = sceneNameToLoad;
            SceneEndingManager.Instance.EndScene();            
        }
    }
}
