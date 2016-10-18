using UnityEngine;
using System.Collections;

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

    public void HandleInput(JoystickState joystickState)
    {
        if (isActive)
        {
            OnHandleInput(joystickState);
        }
    }

    protected abstract void OnEnter();
    protected abstract void OnExit();
    protected abstract void OnUpdate();
    protected abstract void OnHandleInput(JoystickState joystickState);
}
