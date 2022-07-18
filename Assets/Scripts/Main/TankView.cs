/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class TankView : MonoBehaviour, ITakeDamage, IMove
{
    private TankModel _tankModel => GetComponent<TankModel>();

    public abstract void TakeDamage(int damage);

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void MoveRigidbodyPosition(Rigidbody rigidbody, Vector3 direction, float acceleration, float speed)
    {
        rigidbody.MovePosition(rigidbody.position + direction * acceleration * speed);
    }

    public void SetTankCanonShootingState(bool canShoot)
    {
        _tankModel.TankCanon.CanShoot = canShoot;
    }
}
