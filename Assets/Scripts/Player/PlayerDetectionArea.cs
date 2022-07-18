/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerDetectionArea : DetectionArea
{
    public List<EnemyView> TargetEnemies { get; private set; } = new List<EnemyView>(16);

    public override Action OnTargetFinded { get; set; } = null;
    public override Action OnTargetLost { get; set; } = null;

    private void OnTriggerEnter(Collider other)
    {
        EnemyView enteredEnemy = other.GetComponent<EnemyView>();
        if (enteredEnemy != null)
        {
            TargetEnemies.Add(enteredEnemy);
            OnTargetFinded?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyView outEnemy = other.GetComponent<EnemyView>();
        if (outEnemy != null && TargetEnemies.Contains(outEnemy))
        {
            TargetEnemies.Remove(outEnemy);
            OnTargetLost?.Invoke();
        }
    }

    public void ImmediateExitTrigger(Collider other)
    {
        EnemyView outEnemy = other.GetComponent<EnemyView>();
        if (outEnemy != null && TargetEnemies.Contains(outEnemy))
        {
            TargetEnemies.Remove(outEnemy);
            OnTargetLost?.Invoke();
        }
    }
}
