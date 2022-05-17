using UnityEngine;
using UnityEngine.Events;

public class QuestMarkerVisualizer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject destinationMarkerPrefab;

    [Header("Parameter")]
    public QuestManager questManager;
    public bool visualizeMarkersOneAtATime = true;

    // helpers:
    private int index;
    private GameObject currentMarker;

    void Start()
    {
        PlaceMarker();
        QuestManager.QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);
    }

    private Vector3 GetMarkerNextPosition()
    {
        Vector3 destination = questManager.currentActiveQuest.tasks[index].destination;
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
}
