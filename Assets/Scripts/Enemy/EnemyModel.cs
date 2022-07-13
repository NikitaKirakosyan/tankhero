/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public sealed class EnemyModel : CreatureModel
{
    [Header("Way Points Settings")]
    [SerializeField] private Transform[] _wayPoints = new Transform[0];
    public Transform[] WayPoints => _wayPoints;

    public bool LoopWay = false;
    public bool InverseWay { get; set; } = false;
    public int CurrentWayIndex { get; set; }

    public DetectionArea DetectionArea { get; private set; } = null;

    public Rigidbody Rigidbody { get; private set; } = null;
    public NavMeshAgent Agent { get; private set; } = null;

    private void Awake()
    {
        DetectionArea = GetComponentInChildren<DetectionArea>();

        Rigidbody = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
    }
}