using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameState25d : GameState
{
    public GameState25d(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {

    }

    protected override void OnExit()
    {

    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
        for (int i = 0; i < joystickStates.Length; i++)
        {
            JoystickState _stickState = joystickStates[i];
            HeroController _character = gameManager.characters[i];

            //
            if (_character.gameObject.name != "Character" + _stickState.CharacterIndex)
            {
                Debug.LogError("GameState25d: OnHandleInput: character index (" + _character.gameObject.name + " != joystick index" + _stickState.CharacterIndex);
            }

            //jump
            if (_stickState.ButtonY)
            {
                _character.Jump();
            }

            //slide
            
        }
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.SwitchState(new GameStateTransitionTo2d(gameManager));
        }
    }
}
