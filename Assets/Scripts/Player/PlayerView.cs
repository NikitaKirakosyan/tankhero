/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PlayerModel))]
public sealed class PlayerView : TankView
{
    [Inject] private PlayerModel _model = null;

    public Action OnPlayerDied { get; set; } = null;

    public override void Die()
    {
        OnPlayerDied?.Invoke();

        Destroy(gameObject);
    }

    public override void TakeDamage(int damage)
    {
        _model.health -= damage;
        RefreshUI();

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public void Move(Vector3 direction, float acceleration) =>
        MoveRigidbodyPosition(_model.Rigidbody, direction, acceleration, _model.MovementSpeed * Time.deltaTime);

    public void RefreshUI()
    {
        _model.HealthBar.value = _model.health;
    }
}