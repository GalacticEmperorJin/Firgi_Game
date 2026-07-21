using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
public class NameTextInput : MonoBehaviour
{
    public Text name;

    void ChangeText(string newText)
    {
        name.text = newText;
    }
}
