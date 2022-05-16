using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackgroundFadeIn : MonoBehaviour
{
    // parameter:
    public float fadeInDuration = 3.0f;
    public bool playOnAwake = true;

    // singleton:
    public static BackgroundFadeIn Instance { get; private set; }

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
            FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        Color newColor = background.color;
        newColor.a = 1.0f;

        background.color = newColor;

        while (background.color.a > 0.01f)
        {
            newColor.a -= Time.deltaTime / fadeInDuration;

            background.color = newColor;
            yield return null;
        }

        newColor.a = 0.0f;

        background.color = newColor;
    }
}
