using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    // singleton
    public static ProgressTracker Instance { get; private set; }

    void Awake()
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

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        InitializeProgress();
        LoadProgressToStorylineFSM();
        // mark this gameObject to not be destroyed on load:
        DontDestroyOnLoad(this.gameObject);
    }

    public bool IsFirstTimeRunning()
    {
        return !PlayerPrefs.HasKey("FirstRun");
    }

    private void InitializeProgress()
    {
        if (!IsFirstTimeRunning())
        {
            PlayerPrefs.SetInt("FirstRun", 0);
        }
        else
        {
            PlayerPrefs.SetInt("FirstRun", 1);
            PlayerPrefs.SetInt("Prologue", 0);
            PlayerPrefs.SetInt("Chapter1", 0);
            PlayerPrefs.SetInt("Chapter2", 0);
        }
    }

    public void ClearData()
    {
        PlayerPrefs.SetInt(
            "Prologue",
            0
            );
        PlayerPrefs.SetInt(
            "Chapter1",
            0
            );
        PlayerPrefs.SetInt(
            "Chapter2",
            0
            );
        PlayerPrefs.SetInt(
            "Epilogue",
            0
            );
        PlayerPrefs.SetInt(
            "Cutscene1",
            0
            );
        PlayerPrefs.SetInt(
            "Cutscene2",
            0
            );
        PlayerPrefs.SetInt(
            "Cutscene3",
            0
            );
        PlayerPrefs.SetInt(
            "Cutscene4",
            0
            );
        PlayerPrefs.SetInt(
            "LastCutscene",
            0
            );
        PlayerPrefs.SetInt(
            "Quest1",
            0
            );
        PlayerPrefs.SetInt(
            "Quest2",
            0
            );
        PlayerPrefs.SetInt(
            "Quest3",
            0
            );
        PlayerPrefs.SetInt(
            "Quest4",
            0
            );
    }

    private void LoadProgressToStorylineFSM()
    {
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Prologue",
            PlayerPrefs.GetInt("Prologue", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Chapter1",
            PlayerPrefs.GetInt("Chapter1", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Chapter2",
            PlayerPrefs.GetInt("Chapter2", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Epilogue",
            PlayerPrefs.GetInt("Epilogue", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Cutscene1",
            PlayerPrefs.GetInt("Cutscene1", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Cutscene2",
            PlayerPrefs.GetInt("Cutscene2", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Cutscene3",
            PlayerPrefs.GetInt("Cutscene3", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Cutscene4",
            PlayerPrefs.GetInt("Cutscene4", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "LastCutscene",
            PlayerPrefs.GetInt("LastCutscene", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Quest1",
            PlayerPrefs.GetInt("Quest1", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Quest2",
            PlayerPrefs.GetInt("Quest2", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Quest3",
            PlayerPrefs.GetInt("Quest3", 0)
            );
        StorytellingManager.Instance.storytellingFSM.SetInteger(
            "Quest4",
            PlayerPrefs.GetInt("Quest4", 0)
            );
    }

    private void SaveProgressStoryLineFSM()
    {
        PlayerPrefs.SetInt(
            "Prologue",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Prologue")
            );
        PlayerPrefs.SetInt(
            "Chapter1",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Chapter1")
            );
        PlayerPrefs.SetInt(
            "Chapter2",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Chapter2")
            );
        PlayerPrefs.SetInt(
            "Epilogue",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Epilogue")
            );
        PlayerPrefs.SetInt(
            "Cutscene1",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Cutscene1")
            );
        PlayerPrefs.SetInt(
            "Cutscene2",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Cutscene2")
            );
        PlayerPrefs.SetInt(
            "Cutscene3",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Cutscene3")
            );
        PlayerPrefs.SetInt(
            "Cutscene4",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Cutscene4")
            );
        PlayerPrefs.SetInt(
            "LastCutscene",
            StorytellingManager.Instance.storytellingFSM.GetInteger("LastCutscene")
            );
        PlayerPrefs.SetInt(
            "Quest1",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Quest1")
            );
        PlayerPrefs.SetInt(
            "Quest2",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Quest2")
            );
        PlayerPrefs.SetInt(
            "Quest3",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Quest3")
            );
        PlayerPrefs.SetInt(
            "Quest4",
            StorytellingManager.Instance.storytellingFSM.GetInteger("Quest4")
            );
    }
}
