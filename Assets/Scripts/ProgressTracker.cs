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
            PlayerPrefs.SetInt("Cutscene1", 0);
            PlayerPrefs.SetInt("Cutscene2", 0);
            PlayerPrefs.SetInt("Cutscene3", 0);
            PlayerPrefs.SetInt("Cutscene4", 0);
        }
    }

    private void LoadProgressToStorylineFSM()
    {
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
    }
}
