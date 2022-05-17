using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEndingManager : MonoBehaviour
{
    /// <summary>
    /// This class plays a fade out at the end of the scene.
    /// Then launches the next scene.
    /// </summary>
    /// 

    // singleton:
    public static SceneEndingManager Instance { get; private set; }

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
        DontDestroyOnLoad(this.gameObject);
    }

    public void EndScene(string sceneToLoad)
    {
        BackgroundFadeOut.Instance.FadeOut();
        StartCoroutine(LoadSceneCoroutine(sceneToLoad));
    }

    private IEnumerator LoadSceneCoroutine(string sceneToLoad)
    {
        yield return new WaitForSeconds(BackgroundFadeOut.Instance.fadeOutDuration);
        SceneManager.LoadScene(sceneToLoad);
        BackgroundFadeIn.Instance.FadeIn();
    }
}
