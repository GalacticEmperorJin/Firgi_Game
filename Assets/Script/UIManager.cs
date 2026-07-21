using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour

{
    #region || --Singleton -- ||
    public static UIManager Instance { get; set; }
    //creating a singleton instance of the UIManager class to ensure that there is only one instance of the class in the scene at any given time.
    //This is useful for managing UI elements and ensuring that they are not duplicated or lost when switching between scenes.
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializedButtons();
        }
        else
        {
            Destroy(Instance);
        }
    }

    #endregion region

    public TextMeshProUGUI questionText;
    public Button[] answerButtons;

    private void InitializedButtons()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            int index = i; // Capture the current value of i
            answerButtons[i].onClick.AddListener(() => OnAnswerSelected(i));
        }
    }

    private void OnAnswerSelected(int i)
    {
        //QuestionManager.Instance.SubmitAnswer(i);
    }

    public void DisplayQuestion(Question question)
    {
        UnselectAllButtons();

        questionText.text = question.questionText;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i < question.answers.Length)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.answers[i];
                answerButtons[i].gameObject.SetActive(true);
            }
            else
            {
                answerButtons[i].gameObject.SetActive(false);
            }
        }
    }

    private void UnselectAllButtons()
    {
        EventSystem eventSystem = UnityEngine.EventSystems.EventSystem.current;
        if(eventSystem != null)
        {
            eventSystem.SetSelectedGameObject(null);
        }
    }
}
