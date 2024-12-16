using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float xGap;
    public float zGap;
    public float yDistance;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x - xGap, yDistance, player.transform.position.z - zGap);
    }
}
