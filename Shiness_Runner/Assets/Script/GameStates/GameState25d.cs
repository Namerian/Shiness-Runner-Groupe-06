using UnityEngine;
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                info.character.Jump();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                info.character.JumpCancel();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                info.character.SlideStart();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                info.character.SlideStop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                info.character.Ability();
            }
        }

        //##################################
        //extase check
        if (gameManager.Extase == 100f)
        {
            bool _switchMode = true;

            foreach (JoystickState state in joystickStates)
            {
                PlayerInfo _info = state.playerInfo;
                //Debug.Log("GameState25d: HandleInput: checking if player " + _info.index + " is pressing LT RT");

                if (!_info.isDead && _info.activeJoystick == true)
                {
                    //Debug.Log("player " + _info.index + " is not dead and has a controller");
                    if (!(state.axisLT && state.axisRT))
                    {
                        //Debug.Log("player " + _info.index + " is not pressing LT and RT");
                        _switchMode = false;
                    }
                }
            }

            if (_switchMode)
            {
                Debug.Log("all eligible players are pressing LT and RT");
                gameManager.SwitchState(new GameStateTransitionTo2d(gameManager));
                return;
            }
        }

        //##################################
        //normal input


        //for (int i = 0; i < joystickStates.Length; i++)
        foreach(PlayerInfo info in gameManager.GetAllPlayerInfos())
        {
            JoystickState _stickState = null;
            foreach(JoystickState state in joystickStates)
            {
                if(info.index == state.playerInfo.index)
                {
                    _stickState = state;
                    break;
                }
            }

            PlayerInfo _playerInfo = _stickState.playerInfo;
            HeroController _character = _playerInfo.character;

            if (_playerInfo.isDead)
            {
                continue;
            }

            //
            if (_character.gameObject.name != "Character" + (_stickState.playerInfo.index + 1))
            {
                Debug.LogError("GameState25d: OnHandleInput: character index (" + _character.gameObject.name + " != joystick index" + _stickState.playerInfo.index);
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

            //score
            foreach (PlayerInfo info in gameManager.GetAllPlayerInfos())
            {
                if (!info.isDead)
                {
                    info.score += 10 * Time.deltaTime;
                }
            }
        }
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
        player.isDead = true;
        player.character.gameObject.SetActive(false);
    }

    protected override void OnButtonPressed(string buttonName)
    {
    }
}
