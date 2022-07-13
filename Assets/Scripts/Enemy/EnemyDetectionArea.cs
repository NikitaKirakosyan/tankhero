/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public sealed class EnemyDetectionArea : DetectionArea
{
    public PlayerView TargetPlayer { get; private set; } = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerView enteredPlayer = other.GetComponent<PlayerView>();
        if (enteredPlayer != null)
        {
            TargetPlayer = enteredPlayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerView enteredPlayer = other.GetComponent<PlayerView>();
        if (enteredPlayer != null)
        {
            TargetPlayer = null;
        }
    }
}