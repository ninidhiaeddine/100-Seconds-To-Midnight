using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject aboutCanvas;
    public GameObject settingsCanvas;

    public void PlayOnClick()
    {
        SceneEndingManager.Instance.sceneNameToLoad = "Home";
        SceneEndingManager.Instance.EndScene();
    }

    public void AboutOnClick()
    {
        aboutCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void SettingsOnClick()
    {
        settingsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    public void ExitOnClick()
    {
        Application.Quit(0);
    }

    public void BackOnClick()
    {
        aboutCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}
