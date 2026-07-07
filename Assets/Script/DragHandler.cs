using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        transform.SetParent(originalParent.root); // Move to root during drag.
        canvasGroup.blocksRaycasts = false; // Allow raycasts to detect slots below.
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / CanvasScalerReference(); // Drag relative to canvas scale.
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; // Re-enable raycasts after dragging.

        if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag("Slot"))
        {
            // Snap the clone to the slot
            transform.SetParent(eventData.pointerEnter.transform);
            rectTransform.anchoredPosition = Vector2.zero; // Align perfectly in the slot
        }
        else
        {
            // Reset to the original position if not dropped on a valid slot
            transform.SetParent(originalParent);
            rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    private float CanvasScalerReference()
    {
        CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        return scaler != null ? scaler.referenceResolution.x / Screen.width : 1f;
    }
}


