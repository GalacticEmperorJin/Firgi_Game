using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region || --Singleton -- ||
    public static GameManager Instance { get; set; }
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

    public int lives = 3;

    private void Start()
    {
        StartNewGame();
    }

    private void StartNewGame()
    {
        lives = 3;
        QuestionManager.Instance.LoadNextQuestion();
    }

    public void LoseLife()
    {
        lives--;
        if (lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
