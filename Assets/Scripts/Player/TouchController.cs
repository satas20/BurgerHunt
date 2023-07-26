using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 _touchPosition;
    public Vector2 Direction;
    public Vector2 Rotation;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var delta = eventData.position - _touchPosition;
        Direction = delta.normalized;
        Rotation = delta.normalized;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
    }
}