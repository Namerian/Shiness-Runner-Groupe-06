using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateTransitionTo25d : GameState
{
	private Vector3 transitionTo25dPosition = new Vector3 (1.5f, 6.5f, -7.5f);
	private Vector3 transitionTo25dRotation = new Vector3 (35f, 0f, 0f);
	private const float transitionTo25dSize = 4.5f;
	private const float transitionTo25dTime = 1f;

	private float stateTimer;
	private PlayerInfo[] playerInfos;
	private float[] fromX;
	private float[] toX;

	public GameStateTransitionTo25d (GameManager gameManager) : base (gameManager)
	{
	}

	protected override void OnEnter ()
	{
		GameObject[] _extazModeObstacles = GameObject.FindGameObjectsWithTag ("Extaz mode obstacles");
		foreach (GameObject extazObstacle in _extazModeObstacles) {
			extazObstacle.SetActive (false);
		}

        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(false);
        }

        playerInfos = gameManager.GetAllPlayerInfos ();
		fromX = new float[3];
		toX = new float[3];

		for (int i = 0; i < 3; i++) {
			PlayerInfo _info = playerInfos [i];
			fromX [i] = _info.character.transform.localPosition.x;
			toX [i] = _info.previous25dX;

            if(toX[i] < -6.75f)
            {
                toX[i] = 0;
            }
		}

		stateTimer = 0f;
		gameManager.cameraManager.StartTransition (transitionTo25dPosition, transitionTo25dRotation, transitionTo25dSize, transitionTo25dTime);
	}

	protected override void OnExit ()
	{
		GameObject[] _brawlModeObstacles = GameObject.FindGameObjectsWithTag ("Brawl mode obstacles");
		float _xLimit = gameManager.cameraManager.transform.position.x + 5f;
		foreach (GameObject brawlObstacle in _brawlModeObstacles) {
			if (brawlObstacle.transform.position.x >= _xLimit) {
				brawlObstacle.SetActive (true);
			}
		}

        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(true);
        }

        for (int i = 0; i < 3; i++) {
			PlayerInfo _playerInfo = gameManager.GetPlayerInfo (i);

			_playerInfo.isDead = false;
		}
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

		if (stateTimer > 0.25f) {
			float _positioningProgress = (stateTimer - 0.25f) / 0.5f;

			float _firstX = Mathf.SmoothStep (fromX [0], toX [0], _positioningProgress);
			float _secondX = Mathf.SmoothStep (fromX [1], toX [1], _positioningProgress);
			float _thirdX = Mathf.SmoothStep (fromX [2], toX [2], _positioningProgress);

			Vector3 _firstPos = playerInfos [0].character.transform.localPosition;
			Vector3 _secondPos = playerInfos [1].character.transform.localPosition;
			Vector3 _thirdPos = playerInfos [2].character.transform.localPosition;

			playerInfos [0].character.transform.localPosition = new Vector3 (_firstX, _firstPos.y, _firstPos.z);
			playerInfos [1].character.transform.localPosition = new Vector3 (_secondX, _secondPos.y, _secondPos.z);
			playerInfos [2].character.transform.localPosition = new Vector3 (_thirdX, _thirdPos.y, _thirdPos.z);
		}
	}
}
