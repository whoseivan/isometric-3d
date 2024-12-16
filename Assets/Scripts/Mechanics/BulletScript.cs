using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Destroy(this.gameObject);
    }
}
