using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnhancedMovement : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform _target;

    [Header("Agent movement settings")]
    public float _speed;
    public float _distanceToFollow;

    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
    }

    private void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, _target.position) < _distanceToFollow)
        {
            _agent.destination = _target.position;
        }
        else
        {
            _agent.destination = Vector3.zero;
        }
    }
}
