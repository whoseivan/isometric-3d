using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void ExitApp()
    {
        Application.Quit();
    }

    public void ToMainMenu(string MainMenuSceneName)
    {
        SceneManager.LoadScene(MainMenuSceneName);
    }
}
