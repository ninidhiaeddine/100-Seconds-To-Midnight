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
            PlayerPrefs.SetInt("Prologue", 0);
            PlayerPrefs.SetInt("Chapter1", 0);
            PlayerPrefs.SetInt("Chapter2", 0);
        }
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
    }
}
