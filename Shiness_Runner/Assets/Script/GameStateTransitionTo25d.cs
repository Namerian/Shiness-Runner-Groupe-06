using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateTransitionTo25d : GameState
{
	private Vector3 transitionTo25dPosition = new Vector3 (1.5f, 6.5f, -7.5f);
	private Vector3 transitionTo25dRotation = new Vector3 (35f, 0f, 0f);
	private const float transitionTo25dSize = 4.5f;
	private const float transitionTo25dTime = 1.5f;

	private float stateTimer;

	public GameStateTransitionTo25d (GameManager gameManager) : base (gameManager)
	{
	}

	protected override void OnEnter ()
	{
		stateTimer = 0f;

		gameManager.cameraManager.StartTransition (transitionTo25dPosition, transitionTo25dRotation, transitionTo25dSize, transitionTo25dTime);
	}

	protected override void OnExit ()
	{
	}

	protected override void OnHandleInput (JoystickState[] joystickStates)
	{
	}

	protected override void OnUpdate ()
	{
		stateTimer += Time.deltaTime;

		if (stateTimer > transitionTo25dTime) {
			gameManager.SwitchState (new GameState25d (gameManager));
		}
	}
}
