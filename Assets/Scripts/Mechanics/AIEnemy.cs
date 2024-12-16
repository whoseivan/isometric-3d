using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{

    public float distanceToFollow = 10f;

    private NavMeshAgent _agent;
    private GameObject _target;
    private Vector3 _targetTransform;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _targetTransform = _target.transform.position;
        float distance = Vector3.Distance(transform.position, _targetTransform);

        if (distance < distanceToFollow)
        {
            _agent.destination = _targetTransform;
        }
        else
        {
            _agent.destination = transform.position;
        }
    }
}
