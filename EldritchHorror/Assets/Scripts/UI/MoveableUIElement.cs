using GameKit;
using UnityEngine;
using UnityEngine.EventSystems;


public class MoveableUIElement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Vector2 _cashedPosition;
    [SerializeField, ReadOnly] private RectTransform _cashedTransform;
    [SerializeField, Min(0)] private Vector2 _maxDeltaLimit;
    [SerializeField, Min(0)] private Vector2 _minDeltaLimit;

    public void OnBeginDrag(PointerEventData eventData) { }

    public void OnDrag(PointerEventData eventData)
    {
        var pos = eventData.delta + _cashedTransform.anchoredPosition;
        pos.x                             = Mathf.Clamp(pos.x, _cashedPosition.x - _minDeltaLimit.x, _cashedPosition.x + _maxDeltaLimit.x);
        pos.y                             = Mathf.Clamp(pos.y, _cashedPosition.y - _minDeltaLimit.y, _cashedPosition.y + _maxDeltaLimit.y);
        _cashedTransform.anchoredPosition = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.delta.magnitude > 10) { }
    }


    public void OnPointerDown(PointerEventData eventData) { }

    public void OnPointerUp(PointerEventData eventData) { }

    private void Reset()
    {
        _cashedTransform = GetComponent<RectTransform>();
    }

    private void Awake()
    {
        _cashedPosition = _cashedTransform.anchoredPosition;
    }
}