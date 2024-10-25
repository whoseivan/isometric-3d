using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsUI : MonoBehaviour
{
    public GameObject SettingsPanel;

    public void OnSettingsEnter()
    {
        SettingsPanel.SetActive(true);
        Cursor.visible = true;  // Делает курсор видимым
        Cursor.lockState = CursorLockMode.None;  // Разблокирует курсор
        this.gameObject.SetActive(false);
    }

        
}
