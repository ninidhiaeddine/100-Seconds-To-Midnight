using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    // component:
    private AudioSource audioSource;

    // singleton:
    public static DialogManager Instance { get; private set; }

    // dialog:
    public DialogScriptableObject dialog;
    public DialogTextTyper dialogTextTyper;

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
        audioSource = GetComponent<AudioSource>();

        // just for testing:
        StartDialog();
    }

    // public functions:

    public void SetNewDialog(DialogScriptableObject newDialog)
    {
        this.dialog = newDialog;
        UpdateDialogClip();
    }

    public void StartDialog()
    {
        // start text dialog:
        StartCoroutine(StartDialogCoroutine());

        // play dialog clip:
        UpdateDialogClip();
        audioSource.Play();
    }

    // helper functions:

    private IEnumerator StartDialogCoroutine()
    {
        DialogLineDurationPair[] interleavedDialogLines;
        string characterName;

        if (dialog.startWith == Character.Character1)
        {
            interleavedDialogLines = InterleaveArrays<DialogLineDurationPair>(
                dialog.character1LinesDurationPairs,
                dialog.character2LinesDurationPairs
                );

            for (int i = 0; i < interleavedDialogLines.Length; i++)
            {
                // find character name:
                if (i % 2 == 0)
                    characterName = dialog.character1Name;
                else
                    characterName = dialog.character2Name;

                // set full text:
                dialogTextTyper.fullText = characterName + ": " + interleavedDialogLines[i].line;

                // call typer:
                StartCoroutine(dialogTextTyper.TypeText());
                yield return new WaitForSeconds(interleavedDialogLines[i].duration);
            }
        }
        else
        {
            interleavedDialogLines = InterleaveArrays<DialogLineDurationPair>(
                dialog.character2LinesDurationPairs,
                dialog.character1LinesDurationPairs
                );

            for (int i = 0; i < interleavedDialogLines.Length; i++)
            {
                // find character name:
                if (i % 2 == 0)
                    characterName = dialog.character2Name;
                else
                    characterName = dialog.character1Name;

                // set full text:
                dialogTextTyper.fullText = characterName + ": " + interleavedDialogLines[i].line;

                // call typer:
                StartCoroutine(dialogTextTyper.TypeText());
                yield return new WaitForSeconds(interleavedDialogLines[i].duration);
            }

            // TODO: Fix appending character's name when the two arrays are not the same size
        }
    }

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

    private void UpdateDialogClip()
    {
        if (dialog.dialogClip != null)
            audioSource.clip = dialog.dialogClip;
    }
}
