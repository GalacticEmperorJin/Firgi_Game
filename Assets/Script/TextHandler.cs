using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    [SerializeField] InputField inputField; // Current InputField
    [SerializeField] Text resultText;       // Text to display the result
    [SerializeField] string expectedAnswer; // Expected correct answer
    [SerializeField] InputField nextInputField; // Next InputField to focus on

    void Start()
    {
        // Subscribe to the InputField's OnEndEdit event
        inputField.onEndEdit.AddListener(HandleEndEdit);
    }

    void HandleEndEdit(string userInput)
    {
        ValidateInput(userInput); // Validate current input

        // Automatically move to the next InputField if one exists
        if (nextInputField != null)
        {
            EventSystem.current.SetSelectedGameObject(nextInputField.gameObject);
        }
    }

    public void ValidateInput(string input)
    {
        if (input == expectedAnswer)
        {
            resultText.text = "✓";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "✗";
            resultText.color = Color.red;
        }
    }

    void OnDestroy()
    {
        // Clean up the event listener when the object is destroyed
        inputField.onEndEdit.RemoveListener(HandleEndEdit);
    }
}
