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
    public List<Transform> wanderPoints;  // Точки, к которым будет ходить противник
    public float wanderRadius = 5f;       // Радиус для поиска новой точки
    public float wanderDelay = 2f;        // Задержка перед выбором новой точки

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
            // Прекращаем бродяжничество и преследуем игрока
            StopCoroutine(WanderRoutine());
            isWandering = false;
            _agent.destination = _target.position;
        }
        else if (!isWandering)
        {
            // Запускаем корутину для бродяжничества, если не видим игрока
            StartCoroutine(WanderRoutine());
        }
    }

    private IEnumerator WanderRoutine()
    {
        isWandering = true;

        while (true)
        {
            Vector3 wanderPoint;

            // Выбираем случайную точку из списка wanderPoints
            if (wanderPoints.Count > 0)
            {
                wanderPoint = wanderPoints[Random.Range(0, wanderPoints.Count)].position;
            }
            else
            {
                // Если нет заданных точек, выбираем случайное направление в пределах wanderRadius
                Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
                randomDirection += transform.position;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1))
                {
                    wanderPoint = hit.position;
                }
                else
                {
                    continue; // Пропускаем итерацию, если не удалось найти подходящую точку
                }
            }

            _agent.SetDestination(wanderPoint);

            // Ждем перед тем, как выбрать новую точку
            yield return new WaitForSeconds(wanderDelay);
        }
    }
}
