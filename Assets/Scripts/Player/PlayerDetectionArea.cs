/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerDetectionArea : DetectionArea
{
    public List<EnemyView> TargetEnemies { get; private set; } = new List<EnemyView>(16);

    private void OnTriggerEnter(Collider other)
    {
        EnemyView enteredEnemy = other.GetComponent<EnemyView>();
        if (enteredEnemy != null)
        {
            TargetEnemies.Add(enteredEnemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyView enteredEnemy = other.GetComponent<EnemyView>();
        if (enteredEnemy != null && TargetEnemies.Contains(enteredEnemy))
        {
            TargetEnemies.Remove(enteredEnemy);
        }
    }
}
