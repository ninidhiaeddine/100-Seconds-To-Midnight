using UnityEngine;
using System.Collections;

enum Character { Character1, Character2 };

public class DialogManager : MonoBehaviour
{
    public DialogScriptableObject dialog;

    IEnumerator StartDialog()
    {
        int i = 0;
        DialogLineDurationPair lineDurationPair;

        while (true)
        {
            if (i % 2 == 0)
                lineDurationPair = GetLineDurationPair(Character.Character1, i);
            else
                lineDurationPair = GetLineDurationPair(Character.Character2, i);

            // increment:
            i++;

            yield return lineDurationPair.line;
            yield return new WaitForSeconds(lineDurationPair.duration);

            // TODO: IndexOutOfBounds exception will occur here. Needs fixing
        }
    }

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
