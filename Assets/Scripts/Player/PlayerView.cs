/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public sealed class PlayerView : CreatureView
{
    private PlayerModel _model = null;

    public Action OnPlayerDied { get; set; } = null;

    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
    }

    public override void TakeDamage(int damage)
    {
        _model.health -= damage;

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public void Move(Vector3 direction, float acceleration, Space relativeTo = Space.Self) =>
        MoveRigidbodyPosition(_model.Rigidbody, direction, acceleration, _model.MovementSpeed);

    public void SetRotation(float y)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
    }

    public override void Die()
    {
        OnPlayerDied?.Invoke();

        Destroy(gameObject);
    }
}