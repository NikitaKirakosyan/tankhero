/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class CreatureView : MonoBehaviour, ITakeDamage, IMove
{
    public abstract void TakeDamage(int damage);

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed, Space relativeTo = Space.Self)
    {
        rigidbody.MovePosition(rigidbody.position + direction * acceleration * speed * Time.deltaTime);
    }
}
