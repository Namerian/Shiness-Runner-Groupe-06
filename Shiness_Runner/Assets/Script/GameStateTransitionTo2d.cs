using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateTransitionTo2d : GameState
{
	private Vector3 transitionTo2DPosition = new Vector3 (1.25f, 1.25f, -8f);
	private Vector3 transitionTo2DRotation = new Vector3 (0f, 0f, 0f);
	private const float transitionTo2dSize = 2.5f;
	private const float transitionTo2dTime = 1.5f;

	private float stateTimer;

	public GameStateTransitionTo2d (GameManager gameManager) : base (gameManager)
	{
	}

	protected override void OnEnter ()
	{
		stateTimer = 0f;

		gameManager.cameraManager.StartTransition (transitionTo2DPosition, transitionTo2DRotation, transitionTo2dSize, transitionTo2dTime);
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

		if (stateTimer > transitionTo2dTime) {
			gameManager.SwitchState (new GameState2d (gameManager));
		}
	}
}
