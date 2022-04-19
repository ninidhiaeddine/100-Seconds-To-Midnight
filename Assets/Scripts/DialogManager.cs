using UnityEngine;
using System.Collections.Generic;

enum Character { Character1, Character2 };

public class DialogManager : MonoBehaviour
{
    public DialogScriptableObject dialog;

    DialogLineDurationPair GetLineDurationPair(Character character, int index)
    {
        if (character == Character.Character1)
            return dialog.character1LinesDurationPairs[index];
        else if (character == Character.Character2)
            return dialog.character2LinesDurationPairs[index];
        else
            throw new System.Exception("Unexpected value");
    }
}
