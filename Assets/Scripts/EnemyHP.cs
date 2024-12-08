using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    public float enemyHP = 100;
    public Slider enemySliderHP;
    public GameObject expPrefab;

    void Start()
    {
        enemySliderHP.maxValue = 100;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemySliderHP.value = enemyHP;
        if (enemyHP <= 0)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
            Instantiate(expPrefab, position, Quaternion.identity);
            Destroy(gameObject);
        }

    }

    public void ChangeHP(float hpPoints)
    {
        if (enemyHP > 100)
            enemyHP = 100;
        if (enemyHP <= 0)
            Destroy(gameObject);

        enemyHP += hpPoints;
    }
}
