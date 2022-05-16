using UnityEngine;
using UnityEngine.UI;

public class ChapterSceneManager : MonoBehaviour
{
    public Text chapterTitleText;
    public Text chapterDescriptionText;
    public ChapterScriptableObject chapter;

    void Start()
    {
        SetChapterTexts();   
    }

    private void SetChapterTexts()
    {
        chapterTitleText.text = chapter.title;
        chapterDescriptionText.text = chapter.description;
    }
}
