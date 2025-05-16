using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Ruins");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
