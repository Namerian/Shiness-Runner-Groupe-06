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

    private PlayerInfo firstCharacter;
    private float firstFromX, firstToX;

    private PlayerInfo secondCharacter;
    private float secondFromX, secondToX;

    private PlayerInfo thirdCharacter;
    private float thirdFromX, thirdToX;

	public GameStateTransitionTo2d (GameManager gameManager) : base (gameManager)
	{
	}

	protected override void OnEnter ()
	{
        PlayerInfo[] _playerInfos = gameManager.GetAllPlayerInfos();
        for(int i = 0; i < 3; i++)
        {
            _playerInfos[i].previous25dX = _playerInfos[i].character.transform.localPosition.x;
            Debug.Log("GameStateTransitionTo2d: OnEnter: char " + i + ": localX=" + _playerInfos[i].previous25dX);
        }

        float _bestX = -100f;
        foreach(PlayerInfo info in _playerInfos)
        {
            if(info.previous25dX > _bestX)
            {
                _bestX = info.previous25dX;
                firstCharacter = info;
            }
        }

        firstFromX = firstCharacter.previous25dX;
        firstToX = 0;

        _bestX = -100f;
        foreach (PlayerInfo info in _playerInfos)
        {
            if (info.previous25dX > _bestX && info != firstCharacter)
            {
                _bestX = info.previous25dX;
                secondCharacter = info;
            }
        }

        secondFromX = secondCharacter.previous25dX;
        secondToX = 3;

        foreach (PlayerInfo info in _playerInfos)
        {
            if(info != firstCharacter && info != secondCharacter)
            {
                thirdCharacter = info;
            }
        }

        thirdFromX = thirdCharacter.previous25dX;
        thirdToX = 6;







        stateTimer = 0f;
		gameManager.cameraManager.StartTransition (transitionTo2DPosition, transitionTo2DRotation, transitionTo2dSize, transitionTo2dTime);
	}

	protected override void OnExit ()
	{
        for (int i = 0; i < 3; i++)
        {
            PlayerInfo _playerInfo = gameManager.GetPlayerInfo(i);

            _playerInfo.isDead = false;
        }
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
