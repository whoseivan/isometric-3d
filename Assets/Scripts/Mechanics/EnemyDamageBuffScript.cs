using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageBuffScript : MonoBehaviour
{
    public float effect = 1.25f;

    public void ButtonAction()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<enemyScript>().enemyPoints /= effect;

        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
