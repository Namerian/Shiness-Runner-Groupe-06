﻿using UnityEngine;
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
        gameManager.ScoreMultiplier = 2f;
        GameObject.Find("ReferenceBody").GetComponent<ReferenceBodyController>().moveSpeed = 8f;
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

            if (_playerInfo.isDead)
            {
                continue;
            }

            //
            if (_character.gameObject.name != "Character" + (_stickState.characterIndex + 1))
            {
                Debug.LogError("GameState25d: OnHandleInput: character index (" + _character.gameObject.name + " != joystick index" + _stickState.characterIndex);
            }

            //jump
            if (_stickState.buttonA_down)
            {
                _character.Jump();
            }
            else if (_stickState.buttonA_up)
            {
                _character.JumpCancel();
            }

            //slide
            if (_stickState.buttonB_down)
            {
                _character.SlideStart();
            }
            else if (_stickState.buttonB_up)
            {
                _character.SlideStop();
            }
        }
    }

	protected override void OnUpdate ()
	{
		if (Input.GetKeyDown (KeyCode.Y)) {
			gameManager.SwitchState (new GameStateTransitionTo25d (gameManager));
            gameManager.Extase = 0;
            Debug.LogError("You cheated! You shall be punished!");
            return;
		}

        //are players dead
        bool _allPlayersDead = true;
        foreach(PlayerInfo info in gameManager.GetAllPlayerInfos())
        {
            if (!info.isDead)
            {
                _allPlayersDead = false;
            }
        }

        if (_allPlayersDead)
        {
            gameManager.Extase = 0;
            gameManager.SwitchState(new GameStateTransitionTo25d(gameManager));
            return;
        }

        //extase
        gameManager.Extase -= gameManager.extasePerSecond * Time.deltaTime;

        if(gameManager.Extase == 0)
        {
            gameManager.SwitchState(new GameStateTransitionTo25d(gameManager));
            return;
        }
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
        player.isDead = true;
        player.character.gameObject.SetActive(false);
    }
}
