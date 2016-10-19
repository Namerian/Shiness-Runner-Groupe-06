using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GameState2d : GameState
{
	public GameState2d (GameManager gameManager) : base (gameManager)
	{
	}

	protected override void OnEnter ()
	{
	}

	protected override void OnExit ()
	{
	}

	protected override void OnHandleInput (JoystickState[] joystickStates)
	{
	}

	protected override void OnUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Y)) {
			gameManager.SwitchState (new GameStateTransitionTo25d (gameManager));
		}
	}
}
