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
            PlayerInfo _playerInfo = gameManager.GetPlayerInfo(_stickState.characterIndex);
            HeroController _character = _playerInfo.character;

            if (_playerInfo.isDead)
            {
                continue;
            }

            //
            if (_character.gameObject.name != "Character" + (_stickState.characterIndex+1))
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

            //switch lane
            if (_stickState.yAxisUp )
            {
                int _charLane = -1;
                int[] _lanes = gameManager.lanes;
                for (int lane = 0; lane < _lanes.Length; lane++)
                {
                    if (_lanes[lane] == _stickState.characterIndex)
                    {
                        _charLane = lane;
                    }
                }

                if (_charLane != 2)
                {
                    int _otherLane = _charLane + 1;
                    PlayerInfo _otherPlayerInfo = gameManager.GetPlayerInfo(_lanes[_otherLane]);
                    HeroController _otherChar = _otherPlayerInfo.character;

                    if (!_character.transitioning && !_otherChar.transitioning)
                    {
                        gameManager.SwitchLanes(_charLane, _otherLane);
                        _character.LaneUp();
                        _otherChar.LaneDown();
                    }
                }
            }
            else if (_stickState.yAxisDown)
            {
                int _charLane = -1;
                int[] _lanes = gameManager.lanes;
                for (int lane = 0; lane < _lanes.Length; lane++)
                {
                    if (_lanes[lane] == _stickState.characterIndex)
                    {
                        _charLane = lane;
                    }
                }

                if(_charLane != 0)
                {
                    int _otherLane = _charLane - 1;
                    PlayerInfo _otherPlayerInfo = gameManager.GetPlayerInfo(_lanes[_otherLane]);
                    HeroController _otherChar = _otherPlayerInfo.character;

                    if (!_character.transitioning && !_otherChar.transitioning)
                    {
                        gameManager.SwitchLanes(_charLane, _otherLane);
                        _character.LaneDown();
                        _otherChar.LaneUp();
                    }
                }
            }
        }
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.SwitchState(new GameStateTransitionTo2d(gameManager));
        }

        //extase
        gameManager.Extase += gameManager.extasePerSecond * Time.deltaTime;
    }
}
