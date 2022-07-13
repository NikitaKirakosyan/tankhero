/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerModel))]
[RequireComponent(typeof(PlayerView))]
public sealed class PlayerController : MonoBehaviour
{
    [Inject] private PlayerModel _model = null;
    [Inject] private PlayerView _view = null;

    [Inject] private MovementJoystic _movementJoystic = null;

    private void LateUpdate()
    {
        if (_movementJoystic.Direction != Vector3.zero)
        {
            Vector3 direction = new Vector3(_movementJoystic.Direction.x, 0, _movementJoystic.Direction.y);
            transform.rotation = _view.LookAt(direction, _model.AngularSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        _view.Move(transform.forward, _movementJoystic.OffsetDistance);
    }
}