using UnityEngine;
using System.Collections;

public class QuestMarkerVisualizer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject destinationMarkerPrefab;

    [Header("Parameter")]
    public bool visualizeMarkersOneAtATime = true;

    // helpers:
    private int index;
    private GameObject currentMarker;

    void Start()
    {
        StartCoroutine(PlaceMarkerAfterDelay());
        QuestManager.QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);
    }

    private Vector3 GetMarkerNextPosition()
    {
        Vector3 destination = QuestManager.Instance.currentActiveQuest.tasks[index].destination;
        index++;
        return destination;
    }

    private void PlaceMarker()
    {
        try
        {
            Vector3 markerPos = GetMarkerNextPosition();
            currentMarker = Instantiate(destinationMarkerPrefab);
            currentMarker.transform.position = markerPos;
        }
        catch
        {

        }
    }

    // Event Handler:

    private void QuestMarkerReachedEventHandler()
    {
        if (currentMarker != null)
            Destroy(currentMarker.gameObject);
        
        PlaceMarker();
    }

    private IEnumerator PlaceMarkerAfterDelay(float delay = 0.5f)
    {
        yield return new WaitForSeconds(delay);
        PlaceMarker();
    }
}
