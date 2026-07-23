using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestionDB", menuName = "Firgi/Question Archive")]
public class QuestionArchive : ScriptableObject
{
    public Question[] questions;

    public Question getRandomQuestion()
    {
        if (questions.Length == 0 || questions.Length == 0)
        {
            Debug.LogError("No questions available in the archive.");
            return null;
        }
        int randomIndex = UnityEngine.Random.Range(0, questions.Length);
        return questions[randomIndex];
    }
}
