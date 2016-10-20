using UnityEngine;
using System.Collections;
using System;

public class GameStateGameOver : GameState
{
    public GameStateGameOver(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        GameObject _gameOverUI;
        _gameOverUI = GameObject.FindObjectOfType<Canvas>().transform.FindChild("GameOver").gameObject;
        _gameOverUI.SetActive(true);
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
}
