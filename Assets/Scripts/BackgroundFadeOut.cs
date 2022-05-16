using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundFadeOut : MonoBehaviour
{
    // parameter:
    public float fadeOutDuration = 3.0f;
    public bool playOnAwake = true;

    // singleton:
    public static BackgroundFadeOut Instance { get; private set; }

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

        if (playOnAwake)
            FadeOut();
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        Color newColor = background.color;
        newColor.a = 0.0f;

        background.color = newColor;

        while (background.color.a < 0.99f)
        {
            newColor.a += Time.deltaTime / fadeOutDuration;

            background.color = newColor;
            yield return null;
        }

        newColor.a = 1.0f;

        background.color = newColor;
    }
}
