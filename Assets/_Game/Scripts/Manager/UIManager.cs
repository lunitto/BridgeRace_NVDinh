using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] public GameObject joystick;
    [SerializeField] public GameObject startButton;
    [SerializeField] public GameObject winPanel;
    [SerializeField] public GameObject losePanel;

    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void CloseAll()
    {
        startButton.SetActive(false);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        joystick.SetActive(false);
    }
    public void ShowStartButton()
    {
        CloseAll();
        startButton.SetActive(true);
    }

    public void HideStartButton()
    {
        CloseAll();
        startButton.SetActive(false);
    }

    public void ShowWinPanel()
    {
        CloseAll();
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        CloseAll();
        losePanel.SetActive(true);
    }

    public void ShowJoystick()
    {
        joystick.SetActive(true);
    }

    public void HideJoystick()
    {
        joystick.SetActive(false);
    }
}
