using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop2D : MonoBehaviour
{
    Vector3 offset;
    Collider2D collider2d;
    public string destinationTag = "DropArea";

    void Awake()
    {
        collider2d = GetComponent<Collider2D>();
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        collider2d.enabled = false;

        Vector2 mouseWorldPos = MouseWorldPosition();
        Collider2D hitCollider = Physics2D.OverlapPoint(mouseWorldPos);

        if (hitCollider != null && hitCollider.CompareTag(destinationTag))
        {
            transform.position = hitCollider.transform.position + new Vector3(0, 0, -0.01f);
        }

        collider2d.enabled = true;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPos);
    }
}