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
        Debug.Log("Partie Terminée");
    }

    protected override void OnExit()
    {
        throw new NotImplementedException();
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
        throw new NotImplementedException();
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
        throw new NotImplementedException();
    }

    protected override void OnUpdate()
    {
        throw new NotImplementedException();
    }
}
