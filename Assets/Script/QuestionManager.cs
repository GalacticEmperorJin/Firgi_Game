using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    #region || --Singleton -- ||
    public static QuestionManager Instance { get; set; }
    //creating a singleton instance of the UIManager class to ensure that there is only one instance of the class in the scene at any given time.
    //This is useful for managing UI elements and ensuring that they are not duplicated or lost when switching between scenes.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    #endregion region

    public QuestionArchive questionArchive;
    private Question currentQuestion;

    public void LoadNextQuestion()
    {
        currentQuestion = questionArchive.getRandomQuestion();
        // Display the question and options in the UI

        if(currentQuestion != null)
        {
           UIManager.Instance.DisplayQuestion(currentQuestion);
        }
        else
        {
            Debug.Log("No more questions available. The question archive might be empty");
        }
    }

    public void SubmitAnswer(int answerIndex)
    {
        if(currentQuestion == null)
        {
           Debug.LogError("No current question to answer. Please load a question first.");
        }
        if(currentQuestion.IsCorrectAnswer(answerIndex))
        {
            Debug.Log("Correct answer!");
        }
        else
        {
            Debug.Log("No current question to answer.");
            GameManager.Instance.LoseLife();
        }

        LoadNextQuestion();
    }
}
