using UnityEngine;

[CreateAssetMenu(fileName = "Chapter", menuName = "ScriptableObjects/ChapterScriptableObject", order = 2)]
public class ChapterScriptableObject : ScriptableObject
{
    public string title;
    public string description;
}
