using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeDelay;

    private float timeLastSpawn;
    private int createdEnemies = 0;

    private void Start()
    {
        Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (Time.time > timeLastSpawn + timeDelay && createdEnemies <= 3 && GameObject.FindGameObjectsWithTag("Enemy").Length < 10)
        {
            timeLastSpawn = Time.time;
            createdEnemies++;
            Instantiate(enemyPrefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
