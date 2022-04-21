using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextTyper : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Text text;
    public string fullText;
    [Range(0.0f, 1.0f)] public float delay = 0.05f;

    // helper variable:
    private string currentText;

    public IEnumerator TypeText()
    {
        for (int i = 0; i < fullText.Length ; i++)
        {
            currentText = fullText.Substring(0, i);
            text.text = currentText;

            yield return new WaitForSeconds(delay);
        }
        text.text = fullText;
    }
}
