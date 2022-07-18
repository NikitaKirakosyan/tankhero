/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerModel))]
[RequireComponent(typeof(PlayerView))]
public sealed class PlayerController : TankController
{
    [Inject] private PlayerModel _model = null;
    [Inject] private PlayerView _view = null;

    [Inject] private MovementJoystic _movementJoystic = null;

    private void Awake()
    {
        _model.HealthBar.minValue = 0;
        _model.HealthBar.maxValue = _model.maxHealth;
        _view.RefreshUI();
    }

    private void LateUpdate()
    {
        Vector3 target = transform.position + transform.forward;

        if (_model.DetectionArea.TargetEnemies != null && _model.DetectionArea.TargetEnemies.Count > 0)
        {
            target = _model.DetectionArea.TargetEnemies[0].transform.position;
        }

        _model.TankHead.LookAt(target, _model.tankHeadAngularSpeed * Time.deltaTime);

        if (_movementJoystic.Direction != Vector3.zero)
        {
            Vector3 direction = new Vector3(_movementJoystic.Direction.x, 0, _movementJoystic.Direction.y);
            transform.LookAt(direction, _model.AngularSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        _view.Move(transform.forward, _movementJoystic.OffsetDistance);
    }
}