/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public sealed class EnemyModel : CreatureModel
{
    [SerializeField] private Transform[] _wayPoints = new Transform[0];

    public NavMeshAgent Agent { get; private set; } = null;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
}