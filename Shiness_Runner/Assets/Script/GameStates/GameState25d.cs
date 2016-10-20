﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameState25d : GameState
{
    private PlayerInfo[] lanes;

    public GameState25d(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        lanes = new PlayerInfo[3];

        for (int i = 0; i < 3; i++)
        {
            PlayerInfo _info = gameManager.GetPlayerInfo(i);
            lanes[_info.currentLane] = _info;
        }

        gameManager.ScoreMultiplier = 1f;
        GameObject.Find("ReferenceBody").GetComponent<ReferenceBodyController>().ChangeSpeed(6f);
    }

    protected override void OnExit()
    {

    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
        //##################################
        //extase check
        if (gameManager.Extase == 100f)
        {
            bool _switchMode = true;

            foreach (JoystickState state in joystickStates)
            {
                PlayerInfo _info = gameManager.GetPlayerInfo(state.characterIndex);

                if (!_info.isDead && _info.joystick != "")
                {
                    if (!state.axisLT || !state.axisRT)
                    {
                        _switchMode = false;
                    }
                }
            }

            if (_switchMode)
            {
                gameManager.SwitchState(new GameStateTransitionTo2d(gameManager));
            }
        }
        //##################################
        //normal input
        else
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

                //attack
                if (_stickState.buttonX_down)
                {
                    _character.Ability();
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

                //switch lane
                if (_stickState.yAxisUp)
                {
                    int _charLane = _playerInfo.currentLane;

                    if (_charLane != 2)
                    {
                        int _otherLane = _charLane + 1;

                        PlayerInfo _otherPlayerInfo = lanes[_otherLane];
                        HeroController _otherChar = _otherPlayerInfo.character;

                        if (!_character.transitioning && (_otherPlayerInfo.isDead || !_otherChar.transitioning))
                        {
                            _playerInfo.currentLane = _otherLane;
                            _otherPlayerInfo.currentLane = _charLane;

                            lanes[_charLane] = _otherPlayerInfo;
                            lanes[_otherLane] = _playerInfo;

                            _character.LaneUp();
                            _otherChar.LaneDown();
                        }
                    }
                }
                else if (_stickState.yAxisDown)
                {
                    int _charLane = _playerInfo.currentLane;

                    if (_charLane != 0)
                    {
                        int _otherLane = _charLane - 1;
                        PlayerInfo _otherPlayerInfo = lanes[_otherLane];
                        HeroController _otherChar = _otherPlayerInfo.character;

                        if (!_character.transitioning && (_otherPlayerInfo.isDead || !_otherChar.transitioning))
                        {
                            _playerInfo.currentLane = _otherLane;
                            _otherPlayerInfo.currentLane = _charLane;

                            lanes[_charLane] = _otherPlayerInfo;
                            lanes[_otherLane] = _playerInfo;

                            _character.LaneDown();
                            _otherChar.LaneUp();
                        }
                    }
                }
            }
        }
    }

    protected override void OnUpdate()
    {
        bool _gameOver = true;
        foreach (PlayerInfo p in gameManager.GetAllPlayerInfos())
        {
            if (!p.isDead)
            {
                _gameOver = false;
            }
        }

        if (_gameOver)
        {
            gameManager.SwitchState(new GameStateGameOver(gameManager));
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                gameManager.SwitchState(new GameStateTransitionTo2d(gameManager));
                gameManager.Extase = 100;
                Debug.LogError("You cheated! You shall be punished!");
            }

            //extase
            gameManager.Extase += gameManager.extasePerSecond * Time.deltaTime;
        }
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
        player.isDead = true;
        player.character.gameObject.SetActive(false);
    }
}
