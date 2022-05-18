using UnityEngine;
using System.Collections;

public class QuestMarkerVisualizer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject destinationMarkerPrefab;

    [Header("Parameter")]
    public bool visualizeMarkersOneAtATime = true;

    // helpers:
    private GameObject currentMarker;

    void Start()
    {
        StartCoroutine(PlaceMarkerAfterDelay());
        QuestManager.QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);
    }

    private Vector3 GetMarkerNextPosition()
    {
        for (int i = 0; i < QuestManager.Instance.currentActiveQuest.tasks.Length; i++)
        {
            if (!QuestManager.Instance.currentActiveQuest.tasks[i].completed)
                return QuestManager.Instance.currentActiveQuest.tasks[i].destination;
        }
        throw new System.Exception();
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

    private IEnumerator PlaceMarkerAfterDelay(float delay = 0.2f)
    {
        yield return new WaitForSeconds(delay);
        PlaceMarker();
    }
}
