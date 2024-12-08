using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGettingDamage : MonoBehaviour
{
    public float getDamage = 25f;
    public string damageTag = "bullet";

    EnemyHP enemyHP;

    // Start is called before the first frame update
    void Start()
    {
        enemyHP = GetComponent<EnemyHP>();
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == damageTag)
        {
            enemyHP.ChangeHP(-getDamage);
        }
    }
}
