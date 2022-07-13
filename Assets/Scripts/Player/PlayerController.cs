/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;

[RequireComponent(typeof(PlayerModel))]
[RequireComponent(typeof(PlayerView))]
public sealed class PlayerController : MonoBehaviour
{
    private PlayerModel _model = null;
    private PlayerView _view = null;

    private void Awake()
    {
        _model = GetComponent<PlayerModel>();
        _view = GetComponent<PlayerView>();
    }

    private void FixedUpdate()
    {
        _view.Move(transform.forward, MovementJoystic.Instance.OffsetDistance);
    }
}