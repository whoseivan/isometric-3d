using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medkitScript : MonoBehaviour
{
    public int medkitPoints;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("1 " + Time.time);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("2 " + Time.time);
            if (collision.gameObject.GetComponent<PlayerHP>().playerHP < 100)
            {
                Debug.Log("3 " + Time.time);
                collision.gameObject.GetComponent<PlayerHP>().ChangeHP(medkitPoints);
                Destroy(gameObject);
            }
        }
    }
}