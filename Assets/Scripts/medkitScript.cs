using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitScript : MonoBehaviour
{
    public int medkitPoints;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerHP>().playerHP < 100)
            {
                collision.gameObject.GetComponent<PlayerHP>().ChangeHP(medkitPoints);
                Destroy(gameObject);
            }
        }
    }
}