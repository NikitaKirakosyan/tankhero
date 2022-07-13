/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerModel _targetPlayer = null;

    [SerializeField] private float _deltaSpeed = 0.0f;
    private float _followSpeed = 3.5f;

    private Vector3 _offset = Vector3.zero;

    private void Awake()
    {
        if (_targetPlayer == null)
        {
            _targetPlayer = FindObjectOfType<PlayerModel>(true);
        }

        _followSpeed = _targetPlayer.MovementSpeed + _deltaSpeed;
        _offset = transform.position - _targetPlayer.transform.position;
    }

    private void OnEnable()
    {
        FindObjectOfType<PlayerView>().OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        FindObjectOfType<PlayerView>().OnPlayerDied -= OnPlayerDied;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 destination = _offset + _targetPlayer.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, _followSpeed * Time.deltaTime);
    }

    private void OnPlayerDied()
    {
        Destroy(this);
    }
}