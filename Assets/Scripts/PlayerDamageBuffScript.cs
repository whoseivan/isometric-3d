using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageBuffScript : MonoBehaviour
{
    public float effect = 1.25f;

    public void ButtonAction()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(var enemy in enemies)
        {
            enemy.GetComponent<EnemyGettingDamage>().getDamage *= effect;
        }
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
