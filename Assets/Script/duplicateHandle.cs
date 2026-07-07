using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class duplicateHandle : MonoBehaviour
{
    public GameObject prefabToDuplicate; // Assign your prefab in the Inspector
    public Transform buttonTransform;   // Assign the button's Transform in the Inspector
    public Transform parentTransform;  // Assign the parent (e.g., Canvas or folder in the hierarchy)
    public Vector3 offset = new Vector3(1, 0, 0); // Offset to place the duplicate

    public void OnDuplicateButtonClicked()
    {
        if (prefabToDuplicate != null && buttonTransform != null)
        {
            // Calculate the position for the duplicate
            Vector3 duplicatePosition = buttonTransform.position + offset;

            // Instantiate the duplicate
            GameObject duplicate = Instantiate(prefabToDuplicate, duplicatePosition, Quaternion.identity);

            // Set the parent to ensure proper hierarchy placement
            if (parentTransform != null)
            {
                duplicate.transform.SetParent(parentTransform, false); // 'false' retains world position
            }
        }
        else
        {
            Debug.LogWarning("Prefab, Button Transform, or Parent not assigned!");
        }
    }
}