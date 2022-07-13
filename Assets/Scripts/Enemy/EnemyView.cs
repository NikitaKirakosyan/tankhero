/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(EnemyModel))]
public sealed class EnemyView : CreatureView
{
    private EnemyModel _model = null;

    private void Awake()
    {
        _model = GetComponent<EnemyModel>();
    }

    public override void TakeDamage(int damage)
    {
        _model.health -= damage;

        if (_model.health <= 0)
        {
            Die();
        }
    }

    public Quaternion LookAt(Vector3 target)
    {
        Vector3 lookPos = target - transform.position;
        lookPos.y = 0;

        Quaternion rotation = Quaternion.LookRotation(lookPos);

        return Quaternion.Slerp(transform.rotation, rotation, _model.Agent.angularSpeed * Time.deltaTime);
    }

    public void NextWayPoint()
    {
        if (!_model.InverseWay)
        {
            _model.CurrentWayIndex++;

            if (_model.CurrentWayIndex >= _model.WayPoints.Length)
            {
                if (_model.LoopWay)
                {
                    _model.CurrentWayIndex = 0;
                }
                else
                {
                    _model.InverseWay = true;
                    _model.CurrentWayIndex--;
                }
            }
        }
        else
        {
            _model.CurrentWayIndex--;

            if (_model.CurrentWayIndex < 0)
            {
                _model.InverseWay = false;
                _model.CurrentWayIndex++;
            }
        }
    }
}