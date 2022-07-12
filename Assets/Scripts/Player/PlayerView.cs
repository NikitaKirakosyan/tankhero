/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
public sealed class PlayerView : MonoBehaviour, ITakeDamage
{
    private PlayerModel _model = null;

    public Action<AsyncOperation> OnPlayerDied { get; set; } = null;

    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
    }

    public void TakeDamage(int damage)
    {
        _model.health -= damage;

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public void Move(Vector3 direction, float acceleration, Space relativeTo = Space.Self)
    {
        direction = (relativeTo == Space.Self) ? transform.TransformDirection(direction) : direction;
        _model.Rigidbody.MovePosition(_model.Rigidbody.position + direction * acceleration * _model.MovementSpeed * Time.deltaTime);
    }

    public void SetRotation(float y)
    {
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, y, transform.localEulerAngles.z);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}