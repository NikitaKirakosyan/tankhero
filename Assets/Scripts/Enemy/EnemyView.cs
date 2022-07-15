/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyModel))]
public sealed class EnemyView : TankView
{
    private EnemyModel _model = null;

    public bool PathCalculatingWithDelay { get; private set; } = false;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
    }

    public override void Die()
    {
        EnemiesPool.AddToInactive(transform);
        Respawn().Forget();
    }

    public override void TakeDamage(int damage)
    {
        _model.health -= damage;

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public override void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed)
    {
        if (_model.IsStopped)
        {
            return;
        }

        base.MoveRigidbodyPosition(rigidbody, direction, acceleration, speed);
    }

    public void NextWayPoint()
    {
        if (!_model.InverseWay)
        {
            _model.CurrentWayIndex++;

            if (_model.CurrentWayIndex >= _model.WayPoints.Length)
            {
                if (_model.LoopWay)
                {
                    _model.CurrentWayIndex = 0;
                }
                else
                {
                    _model.InverseWay = true;
                    _model.CurrentWayIndex--;
                }
            }
        }
        else
        {
            _model.CurrentWayIndex--;

            if (_model.CurrentWayIndex < 0)
            {
                _model.InverseWay = false;
                _model.CurrentWayIndex++;
            }
        }
    }

    public void NextNavMeshCorner()
    {
        _model.CurrentNavMeshCornerIndex++;
    }

    private void MoveToBeggingOfWay()
    {
        transform.position = _model.WayPoints[0].position;
    }

    public async UniTask Respawn()
    {
        MoveToBeggingOfWay();

        await UniTask.Delay(1000);

        EnemiesPool.AddToActive(transform);
    }

    public void OnPlayerLostOrWayEnded()
    {
        _model.CurrentNavMeshCornerIndex = 0;
    }

    public void CalculatePath()
    {
        OnPlayerLostOrWayEnded();
        Vector3 targetPosition = _model.DetectionArea.FindedPlayer == null ?
            _model.WayPoints[_model.CurrentWayIndex].position : _model.DetectionArea.FindedPlayer.transform.position;

        NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, _model.NavMeshPath);
    }

    public async UniTask CalculatePathWithDelay(float seconds = 0.5f, bool cancelIfPlayerLost = false)
    {
        PathCalculatingWithDelay = true;

        await UniTask.Delay((int)Mathf.Round(seconds * 1000));

        CalculatePath();
        _model.CurrentNavMeshCornerIndex = 0;

        PathCalculatingWithDelay = false;
    }

    public void DrawNavMeshPath()
    {
        for (int i = 0; i < _model.NavMeshPath.corners.Length - 1; i++)
        {
            var currentCorner = _model.NavMeshPath.corners[i];
            var nextCorner = _model.NavMeshPath.corners[i + 1];
            Debug.DrawLine(currentCorner, nextCorner, Color.red);
        }
    }
}