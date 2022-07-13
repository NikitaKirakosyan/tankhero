/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System.Collections.Generic;
using UnityEngine;

public static class EnemiesPool
{
    public static List<Transform> ActiveEnemies { get; private set; } = new List<Transform>(16);
    public static List<Transform> InactiveEnemies { get; private set; } = new List<Transform>(16);

    public static void AddToActive(Transform target)
    {
        target.gameObject.SetActive(true);
        ActiveEnemies.Add(target);

        if (InactiveEnemies.Contains(target))
        {
            InactiveEnemies.Remove(target);
        }
    }

    public static void AddToInactive(Transform target)
    {
        target.gameObject.SetActive(false);
        InactiveEnemies.Add(target);

        if (ActiveEnemies.Contains(target))
        {
            ActiveEnemies.Remove(target);
        }
    }
}