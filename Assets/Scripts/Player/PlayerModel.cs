/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class PlayerModel : CreatureModel
{
    [SerializeField] private float _movementSpeed = 3.5f;
    public float MovementSpeed
    {
        get
        {
            return _movementSpeed;
        }

        private set
        {
            _movementSpeed = value;
        }
    }

    public Rigidbody Rigidbody { get; private set; } = null;

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }
}