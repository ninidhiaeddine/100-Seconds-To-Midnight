using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    // singleton:
    public static DialogManager Instance { get; private set; }

    // dialog:
    public DialogScriptableObject dialog;

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

    private void Start()
    {
        StartCoroutine(StartDialog());
    }

    public IEnumerator StartDialog()
    {
        DialogLineDurationPair[] interleavedDialogLines;
        if (dialog.startWith == Character.Character1)
        {
            interleavedDialogLines = InterleaveArrays<DialogLineDurationPair>(
                dialog.character1LinesDurationPairs, 
                dialog.character2LinesDurationPairs
                );
        }
        else
        {
            interleavedDialogLines = InterleaveArrays<DialogLineDurationPair>(
                dialog.character2LinesDurationPairs,
                dialog.character1LinesDurationPairs
                );
        }

        for (int i = 0; i < interleavedDialogLines.Length; i++)
        {
            Debug.Log(interleavedDialogLines[i].line);
            yield return new WaitForSeconds(interleavedDialogLines[i].duration);
        }
    }

    // helper functions:

    private T[] InterleaveArrays<T>(T[] array1, T[] array2)
    {
        T[] result = new T[array1.Length + array2.Length]; 
        int minLength = Mathf.Min(array1.Length, array2.Length);
        int maxLength = Mathf.Max(array1.Length, array2.Length);

        int i = 0;
        while(i < minLength)
        {
            result[i * 2] = array1[i];
            result[(i * 2) + 1] = array2[i];

            i++;
        }

        int j = i * 2;
        while (i < maxLength)
        {
            if (maxLength == array1.Length)
                result[j] = array1[i];
            else if(maxLength == array2.Length)
                result[j] = array2[i];

            i++;
            j++;
        }
        return result;
    }
}
