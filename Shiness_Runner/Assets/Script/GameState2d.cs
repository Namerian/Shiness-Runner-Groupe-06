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
        for (int i = 0; i < joystickStates.Length; i++)
        {
            JoystickState _stickState = joystickStates[i];
            PlayerInfo _playerInfo = gameManager.GetPlayerInfo(_stickState.characterIndex);
            HeroController _character = _playerInfo.character;

            //
            if (_character.gameObject.name != "Character" + (_stickState.characterIndex + 1))
            {
                Debug.LogError("GameState25d: OnHandleInput: character index (" + _character.gameObject.name + " != joystick index" + _stickState.characterIndex);
            }

            //jump
            if (_stickState.buttonY_down)
            {
                _character.Jump();
            }
            else if (_stickState.buttonY_up)
            {
                //
            }

            //slide
            if (_stickState.buttonA_down)
            {
                _character.SlideStart();
            }
            else if (_stickState.buttonA_up)
            {
                _character.SlideStop();
            }
        }
    }

	protected override void OnUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Y)) {
			gameManager.SwitchState (new GameStateTransitionTo25d (gameManager));
		}
	}
}
