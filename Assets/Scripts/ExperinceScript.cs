using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperinceScript : MonoBehaviour
{
    public int experiencePoints = 25;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<LevelSystem>().GetExperince(experiencePoints);
            Destroy(this.gameObject);
        }
    }

}
