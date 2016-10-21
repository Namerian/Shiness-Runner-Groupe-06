using UnityEngine;
using System.Collections;
using System;

public class GameStateEndGame : GameState
{
    public GameStateEndGame(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        GameObject.FindObjectOfType<ReferenceBodyController>().ChangeSpeed(0f);

        GameObject _endGameUI;
        _endGameUI = GameObject.FindObjectOfType<Canvas>().transform.FindChild("EndGame").gameObject;
        _endGameUI.SetActive(true);
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
