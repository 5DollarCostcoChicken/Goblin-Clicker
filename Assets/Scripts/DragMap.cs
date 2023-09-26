using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragMap : MonoBehaviour, IDragHandler
{
    public Transform MapToScroll;
    public BoxCollider2D topHeaderBoxCollider;
    public BoxCollider2D topBox;
    public BoxCollider2D bottomHeaderBoxCollider;
    public BoxCollider2D bottomBox;
    public BoxCollider2D rightHeaderBoxCollider;
    public BoxCollider2D rightBox;
    public BoxCollider2D leftHeaderBoxCollider;
    public BoxCollider2D leftBox;
    Vector3 anchorPos;
    public void Start()
    {
        anchorPos = GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.delta.y < 0 && !topHeaderBoxCollider.bounds.Intersects(topBox.bounds))
        {
            anchorPos.y += eventData.delta.y / (Screen.height / 1080f);
        }
        if (eventData.delta.y > 0 && !bottomHeaderBoxCollider.bounds.Intersects(bottomBox.bounds))
        {
            anchorPos.y += eventData.delta.y / (Screen.height / 1080f);
        }
        if (eventData.delta.x < 0 && !rightHeaderBoxCollider.bounds.Intersects(rightBox.bounds))
        {
            anchorPos.x += eventData.delta.x / (Screen.width / 1920f);
        }
        if (eventData.delta.x > 0 && !leftHeaderBoxCollider.bounds.Intersects(leftBox.bounds))
        {
            anchorPos.x += eventData.delta.x / (Screen.width / 1920f);
        }
        GetComponent<RectTransform>().anchoredPosition = anchorPos;
    }
}
