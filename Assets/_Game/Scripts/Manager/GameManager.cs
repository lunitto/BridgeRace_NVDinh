using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isWin = false;
    public bool isLose = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        if (isWin)
        {
            UIManager.instance.ShowWinPanel();
        }
        else if (isLose)
        {
            UIManager.instance.ShowLosePanel();
        }
    }

    private void StartGame()
    {
        Time.timeScale = 0f;
        UIManager.instance.ShowStartButton();
        UIManager.instance.HideJoystick();
    }

    public void ClickStart()
    {
        Time.timeScale = 1f;
        UIManager.instance.HideStartButton();
        UIManager.instance.ShowJoystick();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
