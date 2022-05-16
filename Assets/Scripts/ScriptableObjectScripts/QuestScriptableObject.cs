using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/QuestScriptableObject", order = 3)]
public class QuestScriptableObject : ScriptableObject
{
    public string title;
    public string objective;
}
