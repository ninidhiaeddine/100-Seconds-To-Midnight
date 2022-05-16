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
        Color characterNameColor;

        interleavedDialogLines = InterleaveArrays<DialogLineDurationPair>(
            dialog.character1LinesDurationPairs,
            dialog.character2LinesDurationPairs
            );

        for (int i = 0; i < interleavedDialogLines.Length; i++)
        {
            // find character name:
            if (i % 2 == 0)
            {
                characterName = dialog.character1Name;
                characterNameColor = dialog.character1UiColor;
            }

            else
            {
                characterName = dialog.character2Name;
                characterNameColor = dialog.character2UiColor;
            }

            // set full text:
            dialogTextTyper.fullText = GetColorizedCharacterName(characterName, characterNameColor) + ": " + interleavedDialogLines[i].line;

            // set starting index:
            dialogTextTyper.startFromIndex = dialogTextTyper.fullText.IndexOf(":") + 1;

            // call typer:
            StartCoroutine(dialogTextTyper.TypeText());
            yield return new WaitForSeconds(interleavedDialogLines[i].duration);
        }
    }

    private T[] InterleaveArrays<T>(T[] array1, T[] array2)
    {
        T[] result = new T[array1.Length + array2.Length];
        int minLength = Mathf.Min(array1.Length, array2.Length);
        int maxLength = Mathf.Max(array1.Length, array2.Length);

        int i = 0;
        while (i < minLength)
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
            else if (maxLength == array2.Length)
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

    private string GetColorizedCharacterName(string characterName, Color color)
    {
        string hex = ColorUtility.ToHtmlStringRGB(color);
        return "<b><color=#" + hex + ">" + characterName + "</color></b>";
    }
}
