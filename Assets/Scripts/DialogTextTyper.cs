using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextTyper : MonoBehaviour
{
    /// <summary>
    /// This class is responsible for typing the text letter by letter
    /// </summary>


    [Header("Parameters")]
    [SerializeField] private Text text;
    public string fullText;
    [Range(0.0f, 1.0f)] public float delay = 0.05f;
    public int startFromIndex;

    // helper variable:
    private string currentText;

    public IEnumerator TypeText()
    {
        for (int i = startFromIndex; i < fullText.Length ; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;

            yield return new WaitForSeconds(delay);
        }
        text.text = fullText;
    }
}
