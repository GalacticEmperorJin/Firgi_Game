using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    [SerializeField] InputField inputField; // Input field for user input
    [SerializeField] Text resultText;       // Text to display the result
    [SerializeField] string expectedAnswer; // Expected correct answer

    public void ValidateInput()
    {
        string input = inputField.text;

        if (input == expectedAnswer) // Compare input with expected answer
        {
            resultText.text = "Correct!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Try Again!";
            resultText.color = Color.red;
        }
    }
}
