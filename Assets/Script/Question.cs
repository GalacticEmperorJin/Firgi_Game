using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public string questionText;
    public string[] answers;
    public int correctAnswerIndex;

    public bool IsCorrectAnswer(int index)
    {
        return index == correctAnswerIndex;
    }
}
