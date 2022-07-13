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

    public Quaternion LookAt(Vector3 target, float angularSpeed)
    {
        Vector3 lookPos = target - transform.position;
        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);

        return Quaternion.Slerp(transform.rotation, rotation, angularSpeed);
    }

    public void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed, Space relativeTo = Space.Self)
    {
        rigidbody.MovePosition(rigidbody.position + direction * acceleration * speed);
    }
}
