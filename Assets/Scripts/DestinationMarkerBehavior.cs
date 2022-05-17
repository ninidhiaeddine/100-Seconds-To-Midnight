using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class DestinationMarkerBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("SpaceshipPlayer"))
        {
            QuestManager.QuestMarkerReachedEvent.Invoke();
        }
    }
}
