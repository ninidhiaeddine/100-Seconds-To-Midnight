using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundFader : MonoBehaviour
{
    // parameter:
    public float fadeDuration = 3.0f;

    // singleton:
    public static BackgroundFader Instance { get; private set; }

    // component:
    private Image background;

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
        background = GetComponent<Image>();
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine(fadeIn: true));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCoroutine(fadeIn: false));
    }

    private IEnumerator FadeCoroutine(bool fadeIn)
    {
        Color newColor = background.color;
        if (fadeIn)
            newColor.a = 1.0f;
        else
            newColor.a = 0.0f;

        background.color = newColor;

        while(background.color.a > 0.01f)
        {
            if (fadeIn)
                newColor.a -= Time.deltaTime / fadeDuration;
            else
                newColor.a += Time.deltaTime / fadeDuration;

            background.color = newColor;
            yield return null;
        }

        if (fadeIn)
            newColor.a = 0.0f;
        else
            newColor.a = 1.0f;

        background.color = newColor;
    }
}
