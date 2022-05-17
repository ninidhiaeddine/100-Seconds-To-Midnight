using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUIVisualizer : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject questCanvasPrefab;
    public GameObject questTaskPrefab;

    [Header("Parameter")]
    public QuestManager questManager;
    public bool visualizeOnAwake = true;

    // helper variables:
    private GameObject questCanvasInScene;
    private List<Text> tasksTexts;

    private void Start()
    {
        tasksTexts = new List<Text>();
        if (visualizeOnAwake)
        {
            IntantiateQuestCanvas();
            StartCoroutine(PopulateUIAfterDelay());
        }

        QuestManager.QuestMarkerReachedEvent.AddListener(QuestMarkerReachedEventHandler);
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
            questTitleText.text = questManager.currentActiveQuest.title;

            // populate tasks:
            for (int i = 0; i < questManager.currentActiveQuest.tasks.Length; i++)
            {
                GameObject task = Instantiate(questTaskPrefab, questCanvasInScene.transform.GetChild(0).GetChild(1));
                Text taskText = task.GetComponent<Text>();
                taskText.text = questManager.currentActiveQuest.tasks[i].objective;

                // store text to be updated later:
                tasksTexts.Add(taskText);

                // determine whether it's finished or not:
                if (questManager.currentActiveQuest.tasks[i].completed)
                    taskText.text += " <color=#7DFF3C>(Completed)</color>";
                else
                    taskText.text += " <color=#FF077C>(Unfinished)</color>";
            }
        }
    }

    public void UpdateQuestTasks()
    {
        for (int i = 0; i < tasksTexts.Count; i++)
        {
            // determine whether it's finished or not:
            if (questManager.currentActiveQuest.tasks[i].completed)
                tasksTexts[i].text = questManager.currentActiveQuest.tasks[i].objective + " <color=#7DFF3C>(Completed)</color>";
            else
                tasksTexts[i].text = questManager.currentActiveQuest.tasks[i].objective + " <color=#FF077C>(Unfinished)</color>";
        }
    }

    private void QuestMarkerReachedEventHandler()
    {
        UpdateQuestTasks();
    }

    private IEnumerator PopulateUIAfterDelay(float delay=0.5f)
    {
        yield return new WaitForSeconds(delay);
        PopulateQuestCanvasInScene();
    }
}
