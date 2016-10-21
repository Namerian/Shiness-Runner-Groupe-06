using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class GameState {

    protected bool isActive;
    protected GameManager gameManager;

    protected GameState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public void Enter()
    {
        if (!isActive)
        {
            isActive = true;
            OnEnter();
        }
    }

    public void Exit()
    {
        if (isActive)
        {
            isActive = false;
            OnExit();
        }
    }

    public void Update()
    {
        if (isActive)
        {
            OnUpdate();
        }
    }

    public void HandleInput(JoystickState[] joystickStates)
    {
        if (isActive)
        {
            OnHandleInput(joystickStates);
        }
    }

    public void PlayerDied(PlayerInfo player)
    {
        if (isActive)
        {
            OnPlayerDied(player);
        }
    }

    public void ButtonPressed(string buttonName)
    {
        if (isActive)
        {
            OnButtonPressed(buttonName);
        }
    }

    protected abstract void OnEnter();
    protected abstract void OnExit();
    protected abstract void OnUpdate();
    protected abstract void OnHandleInput(JoystickState[] joystickStates);
    protected abstract void OnPlayerDied(PlayerInfo player);
    protected abstract void OnButtonPressed(string buttonName);
}
