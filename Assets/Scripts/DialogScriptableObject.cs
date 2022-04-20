using UnityEngine;

public enum Character { Character1, Character2 }

[CreateAssetMenu(fileName = "Dialog", menuName = "ScriptableObjects/DialogScriptableObject", order = 1)]
public class DialogScriptableObject : ScriptableObject
{
    public string character1Name;
    public string character2Name;
    public DialogLineDurationPair[] character1LinesDurationPairs;
    public DialogLineDurationPair[] character2LinesDurationPairs;
    public Character startWith = Character.Character1;
}