using UnityEngine;

public enum Character { Character1, Character2 }

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/DialogScriptableObject", order = 1)]
public class DialogScriptableObject : ScriptableObject
{
    public AudioClip dialogClip;
    public string character1Name, character2Name;
    public Color character1UiColor, character2UiColor;
    public DialogLineDurationPair[] character1LinesDurationPairs;
    public DialogLineDurationPair[] character2LinesDurationPairs;
}