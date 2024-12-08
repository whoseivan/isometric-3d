using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject PausePanel;

    private bool isPanelActive = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPanelActive = !isPanelActive;

            if (isPanelActive)
            {
                PausePanel.SetActive(true);
            }
            else
            {
                PausePanel.SetActive(false);
            }
        }
    }
}
