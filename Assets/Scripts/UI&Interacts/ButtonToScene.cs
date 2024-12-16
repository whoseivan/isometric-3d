using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToScene : MonoBehaviour
{
    public void buttonAction(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
