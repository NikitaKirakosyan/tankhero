/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public interface IMove
{
    public void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed);
}