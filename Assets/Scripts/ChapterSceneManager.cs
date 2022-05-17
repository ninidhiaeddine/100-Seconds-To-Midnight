using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChapterSceneManager : MonoBehaviour
{
    // parameters:
    public Text chapterTitleText;
    public Text chapterDescriptionText;
    public ChapterScriptableObject chapter;
    public float durationBeforeLoadingScene = 4.0f;

    // singleton:
    public static ChapterSceneManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        SetChapterTexts();
        StartCoroutine(NotifyDone());
    }

    public void UpdateChapter(ChapterScriptableObject newChapter)
    {
        this.chapter = newChapter;
        SetChapterTexts();
    }

    private void SetChapterTexts()
    {
        chapterTitleText.text = chapter.title;
        chapterDescriptionText.text = chapter.description;
    }

    private IEnumerator NotifyDone()
    {
        yield return new WaitForSeconds(durationBeforeLoadingScene);
        Debug.Log(chapter.name);
        StorytellingManager.Instance.storytellingFSM.SetInteger(chapter.name, 1);
    }
}
