using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void OnSettingsEnter()
    {
        SettingsPanel.SetActive(true);
        Cursor.visible = true;  // ������ ������ �������
        Cursor.lockState = CursorLockMode.None;  // ������������ ������
        this.gameObject.SetActive(false);
    }

        
}
