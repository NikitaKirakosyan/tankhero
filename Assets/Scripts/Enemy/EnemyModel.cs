/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public sealed class EnemyModel : TankModel
{
    [Header("Way Points Settings")]
    [SerializeField] private Transform[] _wayPoints = new Transform[0];
    public Transform[] WayPoints => _wayPoints;

    public bool LoopWay = false;
    public bool InverseWay { get; set; } = false;
    public int CurrentWayIndex { get; set; }

    private EnemyDetectionArea _detectionArea = null;
    public EnemyDetectionArea DetectionArea
    {
        get
        {
            _detectionArea = GetComponentInChildren<EnemyDetectionArea>();
            if (_detectionArea == null)
            {
                Debug.LogError("Detection Area missed! Created new with default");
                _detectionArea = InitializeDetectionArea<EnemyDetectionArea>();
            }

            return _detectionArea;
        }
    }

    private NavMeshAgent _agent = null;
    public NavMeshAgent Agent => _agent == null ? _agent = GetComponent<NavMeshAgent>() : _agent;
}