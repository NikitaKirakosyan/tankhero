/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(RectTransform))]
public sealed class MovementJoystic : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [Inject] private PlayerView _playerView = null;

    public Vector3 Direction
    {
        get
        {
            return (Vector3)RectTransform.anchoredPosition - Vector3.zero;
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
    }

    private void OnEnable()
    {
        _playerView.OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerView.OnPlayerDied -= OnPlayerDied;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransform.position = Input.mousePosition;
        RectTransform.anchoredPosition = Vector2.ClampMagnitude(RectTransform.anchoredPosition, RectParent.sizeDelta.x / 2);
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