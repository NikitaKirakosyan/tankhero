/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerModel))]
public sealed class PlayerView : CreatureView
{
    [Inject] private PlayerModel _model = null;

    public Action OnPlayerDied { get; set; } = null;

    public override void TakeDamage(int damage)
    {
        _model.health -= damage;

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public void Move(Vector3 direction, float acceleration, Space relativeTo = Space.Self) =>
        MoveRigidbodyPosition(_model.Rigidbody, direction, acceleration, _model.MovementSpeed * Time.deltaTime);

    public override void Die()
    {
        OnPlayerDied?.Invoke();

        Destroy(gameObject);
    }
}