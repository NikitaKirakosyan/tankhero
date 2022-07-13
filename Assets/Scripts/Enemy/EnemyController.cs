/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(EnemyModel))]
[RequireComponent(typeof(EnemyView))]
public sealed class EnemyController : MonoBehaviour
{
    private EnemyModel _model = null;
    private EnemyView _view = null;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
        _view = GetComponent<EnemyView>();
    }

    private void Update()
    {
        transform.rotation = _view.LookAt(_model.WayPoints[_model.CurrentWayIndex].position, _model.Agent.angularSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        _view.MoveRigidbodyPosition(_model.Rigidbody, transform.forward, 1.0f, _model.Agent.speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _model.WayPoints[_model.CurrentWayIndex].position) <= _model.Agent.stoppingDistance)
        {
            _view.NextWayPoint();
        }
    }
}