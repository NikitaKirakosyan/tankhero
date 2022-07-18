/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public abstract class TankController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        float minImpulseMagnitudeToGiveDamage = 0.35f;

        var targetOfDamage = collision.transform.GetComponent(typeof(ITakeDamage)) as ITakeDamage;
        if (targetOfDamage != null && collision.impulse.magnitude >= minImpulseMagnitudeToGiveDamage)
        {
            var model = GetComponent<TankModel>();
            int damage = Mathf.RoundToInt(model.collisionDamage * collision.impulse.magnitude);
            targetOfDamage.TakeDamage(damage);
        }
    }
}