/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public sealed class PlayerModel : TankModel
{
    [Header("Movement Settings")]
    public float AngularSpeed = 30.0f;
    public float MovementSpeed = 3.5f;

    [Header("UI")]
    [SerializeField] private Slider _healthBar = null;
    public Slider HealthBar => _healthBar;

    private PlayerDetectionArea _detectionArea = null;
    public PlayerDetectionArea DetectionArea
    {
        get
        {
            _detectionArea = GetComponentInChildren<PlayerDetectionArea>();
            if (_detectionArea == null)
            {
                Debug.LogError("Detection Area missed! Created new with default");
                _detectionArea = InitializeDetectionArea<PlayerDetectionArea>();
            }

            return _detectionArea;
        }
    }
}