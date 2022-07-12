/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

public sealed class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerModel _target = null;

    [SerializeField] private float _deltaSpeed = 0.0f;
    private float _followSpeed = 3.5f;

    private Vector3 _offset = Vector3.zero;

    private void Awake()
    {
        if (_target == null)
        {
            _target = FindObjectOfType<PlayerModel>(true);
        }

        _followSpeed = _target.MovementSpeed + _deltaSpeed;
        _offset = transform.position - _target.transform.position;
    }

    private void FixedUpdate()
    {
        Follow();
    }

    private void Follow()
    {
        Vector3 destination = _offset + _target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, destination, _followSpeed * Time.deltaTime);
    }
}