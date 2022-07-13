/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class TankView : MonoBehaviour, ITakeDamage, IMove
{
    public abstract void TakeDamage(int damage);

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed)
    {
        rigidbody.MovePosition(rigidbody.position + direction * acceleration * speed);
    }
}
