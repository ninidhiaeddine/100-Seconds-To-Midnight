using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUIVisualizer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject questCanvasPrefab;
    public GameObject questTaskPrefab;

    // helper variables:
    private GameObject questCanvasInScene;
    private List<Text> tasksTexts;

    private void Start()
    {
        tasksTexts = new List<Text>();

        QuestManager.QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);
        QuestManager.QuestChangedEvent.AddListener(QuestChangedEventHandler);
    }

    private void IntantiateQuestCanvas()
    {
        questCanvasInScene = Instantiate(questCanvasPrefab);
    }

    public void PopulateQuestCanvasInScene()
    {
        if (questCanvasInScene != null)
        {
            // update quest title:
            Text questTitleText = questCanvasInScene.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>();
            questTitleText.text = QuestManager.Instance.currentActiveQuest.title;

            // populate tasks:
            for (int i = 0; i < QuestManager.Instance.currentActiveQuest.tasks.Length; i++)
            {
                GameObject task = Instantiate(questTaskPrefab, questCanvasInScene.transform.GetChild(0).GetChild(1));
                Text taskText = task.GetComponent<Text>();
                taskText.text = QuestManager.Instance.currentActiveQuest.tasks[i].objective;

                // store text to be updated later:
                tasksTexts.Add(taskText);

                // determine whether it's finished or not:
                if (QuestManager.Instance.currentActiveQuest.tasks[i].completed)
                    taskText.text += " <color=#7DFF3C>(Completed)</color>";
                else
                    taskText.text += " <color=#FF077C>(Unfinished)</color>";
            }
        }
    }

    public void UpdateQuestTasksCanvas()
    {
        for (int i = 0; i < tasksTexts.Count; i++)
        {
            // determine whether it's finished or not:
            if (QuestManager.Instance.currentActiveQuest.tasks[i].completed)
                tasksTexts[i].text = QuestManager.Instance.currentActiveQuest.tasks[i].objective + " <color=#7DFF3C>(Completed)</color>";
            else
                tasksTexts[i].text = QuestManager.Instance.currentActiveQuest.tasks[i].objective + " <color=#FF077C>(Unfinished)</color>";
        }
    }

    private void QuestMarkerReachedEventHandler()
    {
        UpdateQuestTasksCanvas();
    }

    private void QuestChangedEventHandler()
    {
        StartCoroutine(PopulateUIAfterDelay());
    }

    private IEnumerator PopulateUIAfterDelay(float delay=0.2f)
    {
        yield return new WaitForSeconds(delay);
        Destroy(questCanvasInScene);
        IntantiateQuestCanvas();
        PopulateQuestCanvasInScene();
    }
}
