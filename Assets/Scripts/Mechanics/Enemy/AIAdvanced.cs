using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAdvanced : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform _target;

    [Header("Agent movement settings")]
    public float _speed;
    public float _distanceToFollow;

    [Header("Wandering settings")]
    public List<Transform> wanderPoints;  // �����, � ������� ����� ������ ���������
    public float wanderRadius = 5f;       // ������ ��� ������ ����� �����
    public float wanderDelay = 2f;        // �������� ����� ������� ����� �����

    private NavMeshAgent _agent;
    private bool isWandering;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = _speed;
        isWandering = false;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _target.position);

        if (distanceToTarget < _distanceToFollow)
        {
            // ���������� �������������� � ���������� ������
            StopCoroutine(WanderRoutine());
            isWandering = false;
            _agent.destination = _target.position;
        }
        else if (!isWandering)
        {
            // ��������� �������� ��� ��������������, ���� �� ����� ������
            StartCoroutine(WanderRoutine());
        }
    }

    private IEnumerator WanderRoutine()
    {
        isWandering = true;

        while (true)
        {
            Vector3 wanderPoint;

            // �������� ��������� ����� �� ������ wanderPoints
            if (wanderPoints.Count > 0)
            {
                wanderPoint = wanderPoints[Random.Range(0, wanderPoints.Count)].position;
            }
            else
            {
                // ���� ��� �������� �����, �������� ��������� ����������� � �������� wanderRadius
                Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
                randomDirection += transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
                {
                    wanderPoint = hit.position;
                }
                else
                {
                    continue; // ���������� ��������, ���� �� ������� ����� ���������� �����
                }
            }

            _agent.SetDestination(wanderPoint);

            // ���� ����� ���, ��� ������� ����� �����
            yield return new WaitForSeconds(wanderDelay);
        }
    }
}
