using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PanelAction();
        }
    }

    public void PanelAction()
    {
        isPaused = !isPaused;
        if (!isPaused)
        {
            Time.timeScale = 1;
            Cursor.visible = false;  // �������� ������
            Cursor.lockState = CursorLockMode.Locked;  // ��������� ������ � ������ ������

            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Cursor.visible = true;  // ������ ������ �������
            Cursor.lockState = CursorLockMode.None;  // ������������ ������

            GameObject.FindObjectOfType<QuestManager>().ShowActiveQuestsInScrollView();
            pausePanel.SetActive(true);
        }
    }
}
