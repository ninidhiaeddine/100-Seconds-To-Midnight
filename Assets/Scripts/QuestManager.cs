using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public static UnityEvent QuestMarkerReachedEvent;
    public static UnityEvent<string> QuestCompletedEvent;
    public QuestScriptableObject currentActiveQuest;

    // singelton:
    public static QuestManager Instance;

    // helper:
    int index;

    private void Awake()
    {
        // initialize singleton:
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // dont destroy on load:
        DontDestroyOnLoad(this.gameObject);

        // initialize events:
        if (QuestMarkerReachedEvent == null)
            QuestMarkerReachedEvent = new UnityEvent();
        if (QuestCompletedEvent == null)
            QuestCompletedEvent = new UnityEvent<string>();

        QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);

        index = 0;
    }

    private void QuestMarkerReachedEventHandler()
    {
        currentActiveQuest.tasks[index].completed = true;
        index++;

        if (index >= currentActiveQuest.tasks.Length)
        {
            currentActiveQuest.completed = true;
            StorytellingManager.Instance.storytellingFSM.SetInteger(currentActiveQuest.name, 1);
            QuestCompletedEvent.Invoke(currentActiveQuest.name);
        }
    }

    public static void MarkQuestTaskAsComplete(QuestScriptableObject questScriptableObject, int taskIndex)
    {
        questScriptableObject.tasks[taskIndex].completed = true;
    }

    public static void MarkQuestAsComplete(QuestScriptableObject questScriptableObject)
    {
        questScriptableObject.completed = true;
    }
}
