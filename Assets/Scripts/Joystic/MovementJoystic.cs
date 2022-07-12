/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public sealed class MovementJoystic : Singleton<MovementJoystic>, IDragHandler, IEndDragHandler
{
    [SerializeField] private PlayerView _playerView = null;

    public Vector2 Direction
    {
        get
        {
            return RectTransform.anchoredPosition - Vector2.zero;
        }
    }
    public float OffsetDistance
    {
        get
        {
            return Vector2.Distance(RectTransform.anchoredPosition, Vector2.zero) / (RectParent.sizeDelta.x / 2);
        }
    }
    public float OffsetAngle
    {
        get
        {
            var targetDirection = RectTransform.anchoredPosition - Vector2.zero;
            var angle = Vector2.Angle(targetDirection, RectTransform.up) * (RectTransform.anchoredPosition.x > 0 ? 1 : -1);
            return angle;
        }
    }

    public RectTransform RectTransform { get; private set; } = null;
    public RectTransform RectParent { get; private set; } = null;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        RectParent = RectTransform.parent.GetComponent<RectTransform>();

        if (_playerView == null)
        {
            _playerView = FindObjectOfType<PlayerView>(true);
        }
    }

    private void OnEnable()
    {
        _playerView.OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerView.OnPlayerDied -= OnPlayerDied;
    }

    private void FixedUpdate()
    {
        _playerView.Move(Vector3.forward, OffsetDistance);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.position = Input.mousePosition;
        RectTransform.anchoredPosition = Vector2.ClampMagnitude(RectTransform.anchoredPosition, RectParent.sizeDelta.x / 2);

        _playerView.SetRotation(OffsetAngle);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RectTransform.anchoredPosition = Vector2.zero;
    }

    private void OnPlayerDied()
    {
        Destroy(transform.parent.gameObject);
    }
}