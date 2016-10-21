using UnityEngine;
using UnityEngine.SceneManagement;

using System.Collections;
using System;

public class GameStateGameOver : GameState
{
    private GameObject gameOverUI;

    public GameStateGameOver(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        GameObject.FindObjectOfType<ReferenceBodyController>().ChangeSpeed(0f);

        gameOverUI = GameObject.FindObjectOfType<Canvas>().transform.FindChild("GameOver").gameObject;
        gameOverUI.SetActive(true);
    }

    protected override void OnExit()
    {
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
    }

    protected override void OnUpdate()
    {
    }

    protected override void OnButtonPressed(string buttonName)
    {
        if(buttonName == "Retry")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if(buttonName == "Quit")
        {
            Application.Quit();
        }
    }
}
