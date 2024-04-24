using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneManager : MonoBehaviour
{
    public void LoadGame()
    {
        LoadScene(1);
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        LoadScene(1);
    }

    public void LoadScene(int index)
    {
        if (index < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(index);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
