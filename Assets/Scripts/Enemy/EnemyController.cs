/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyModel))]
[RequireComponent(typeof(EnemyView))]
public sealed class EnemyController : TankController
{
    private EnemyModel _model = null;
    private EnemyView _view = null;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
        _view = GetComponent<EnemyView>();

        if (_model.DetectionArea.RootEnemyModel == null)
        {
            _model.DetectionArea.RootEnemyModel = _model;
        }

        _model.NavMeshPath = new NavMeshPath();
    }

    private void OnEnable()
    {
        EnemiesPool.AddToActive(transform);

        _model.DetectionArea.OnTargetPlayerFinded += _view.CalculatePath;
        _model.DetectionArea.OnTargetPlayerLost += _view.CalculatePath;
    }

    private void OnDisable()
    {
        _model.DetectionArea.OnTargetPlayerFinded -= _view.CalculatePath;
        _model.DetectionArea.OnTargetPlayerLost -= _view.CalculatePath;
    }

    private void Start()
    {
        _view.CalculatePath();
    }

    private void Update()
    {
        _view.DrawNavMeshPath();

        Vector3 target = _model.NavMeshPath.status != NavMeshPathStatus.PathInvalid
            ? _model.NavMeshPath.corners[_model.CurrentNavMeshCornerIndex]
            : transform.position + transform.forward;
        Vector3 towerTarget = _model.DetectionArea.CurrentEnteredPlayer != null
            ? _model.DetectionArea.CurrentEnteredPlayer.transform.position
            : target;

        if (_model.DetectionArea.CurrentEnteredPlayer != null && _model.Distance <= _model.Agent.stoppingDistance)
        {
            target = _model.DetectionArea.CurrentEnteredPlayer.transform.position;
        }

        _model.TankHead.LookAt(towerTarget, _model.tankHeadAngularSpeed * Time.deltaTime);
        transform.LookAt(target, _model.Agent.angularSpeed * Time.deltaTime);

        _model.IsStopped = false;
        if (_model.Distance <= _model.Agent.stoppingDistance)
        {
            if (_model.CurrentNavMeshCornerIndex < _model.NavMeshPath.corners.Length - 1)
            {
                _view.NextNavMeshCorner();
            }
            else if (_model.DetectionArea.FindedPlayer == null)
            {
                _view.OnPlayerLostOrWayEnded();
                _view.NextWayPoint();
                _view.CalculatePath();
            }
            else
            {
                if (!_view.PathCalculatingWithDelay)
                {
                    _view.CalculatePathWithDelay(0.1f, true).Forget();
                }
                _model.IsStopped = true;
            }
        }
    }

    private void FixedUpdate()
    {
        _view.MoveRigidbodyPosition(_model.Rigidbody, transform.forward, 1.0f, _model.Agent.speed * Time.deltaTime);
    }
}