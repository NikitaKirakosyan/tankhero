/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class EnemyDetectionArea : DetectionArea
{
    public bool PlayerLostAsyncStarted { get; private set; } = false;

    public EnemyModel RootEnemyModel { get; set; } = null;

    /// <summary>
    /// Если ИИ совсем потерял танчик (после того как достиг точки,
    /// где он был последний раз замечен) то = null;
    /// </summary>
    public PlayerView FindedPlayer { get; private set; } = null;
    public PlayerView CurrentEnteredPlayer { get; private set; } = null;

    public Action OnTargetPlayerFinded { get; set; } = null;
    public Action OnTargetPlayerLost { get; set; } = null;

    private void OnTriggerEnter(Collider other)
    {
        PlayerView enteredPlayer = other.GetComponent<PlayerView>();
        if (enteredPlayer != null)
        {
            CurrentEnteredPlayer = enteredPlayer;
            FindedPlayer = enteredPlayer;
            OnTargetPlayerFinded?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerView enteredPlayer = other.GetComponent<PlayerView>();
        if (enteredPlayer != null)
        {
            CurrentEnteredPlayer = null;
            if (!PlayerLostAsyncStarted)
            {
                OnTargetPlayerLostAsync().Forget();
            }
        }
    }

    private async UniTask OnTargetPlayerLostAsync()
    {
        PlayerLostAsyncStarted = true;

        await UniTask.WaitUntil(() => RootEnemyModel.CurrentWayIndex >= RootEnemyModel.NavMeshPath.corners.Length - 2);

        FindedPlayer = CurrentEnteredPlayer;
        if (FindedPlayer == null)
        {
            OnTargetPlayerLost?.Invoke();
        }

        PlayerLostAsyncStarted = false;
    }
}