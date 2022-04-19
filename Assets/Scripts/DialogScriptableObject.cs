using UnityEngine;

public enum StartWith { Character1, Character2 }

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/DialogScriptableObject", order = 1)]
public class DialogScriptableObject : ScriptableObject
{
    public DialogLineDurationPair[] character1LinesDurationPairs;
    public DialogLineDurationPair[] character2LinesDurationPairs;
    public StartWith startWith = StartWith.Character1;
}