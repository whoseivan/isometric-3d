using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesCount : MonoBehaviour
{
    public TMP_Text enemiesCount;

    int allEnemies;
    int currentEnemies;

    private void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        currentEnemies = allEnemies;
        enemiesCount.text = $"Enemies: {currentEnemies}/{allEnemies}";
    }

    public void EnemyKilled()
    {
        currentEnemies--;
        enemiesCount.text = $"Enemies: {currentEnemies}/{allEnemies}";
    }
}
