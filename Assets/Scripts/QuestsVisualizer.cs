using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsVisualizer : MonoBehaviour
{
    public GameObject questCanvasPrefab;
    public GameObject questTaskPrefab;
    public QuestScriptableObject questScriptableObject;
    public bool visualizeOnAwake = true;

    private GameObject questCanvasInScene;

    private void Start()
    {
        if (visualizeOnAwake)
        {
            IntantiateQuestCanvas();
            PopulateQuestCanvasInScene();
        }
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
            questTitleText.text = questScriptableObject.title;

            // populate tasks:
            for (int i = 0; i < questScriptableObject.tasks.Length; i++)
            {
                GameObject task = Instantiate(questTaskPrefab, questCanvasInScene.transform.GetChild(0).GetChild(1));
                Text taskText = task.GetComponent<Text>();
                taskText.text = questScriptableObject.tasks[i].objective;

                // determine whether it's finished or not:
                if (questScriptableObject.tasks[i].completed)
                    taskText.text += " <color=#7DFF3C>(Completed)</color>";
                else
                    taskText.text += " <color=#FF077C>(Unfinished)</color>";
            }
        }
    }
}
