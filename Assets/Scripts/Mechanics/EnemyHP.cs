using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float enemyHP = 100;
    public Slider enemySliderHP;
    public GameObject expPrefab;

    private EnemiesCount enemiesCount;
    void Start()
    {
        enemiesCount = FindObjectOfType<EnemiesCount>();

        enemySliderHP.maxValue = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemySliderHP.value = enemyHP;
    }

    public void ChangeHP(float hpPoints)
    {
        enemyHP += hpPoints;

        if (enemyHP > 100)
            enemyHP = 100;
        if (enemyHP <= 0)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z);
            Instantiate(expPrefab, transform.position, Quaternion.identity);
            enemiesCount.EnemyKilled();
            Destroy(gameObject);
        }
    }
}
