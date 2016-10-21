using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameStateTransitionTo25d : GameState
{
    private Vector3 transitionTo25dPosition = new Vector3(1.5f, 6.5f, -7.5f);
    private Vector3 transitionTo25dRotation = new Vector3(35f, 0f, 0f);
    private const float transitionTo25dSize = 4.5f;
    private const float transitionTo25dTime = 0.5f;

    private float stateTimer;
    private PlayerInfo[] playerInfos;
    private float[] fromX;
    private float[] toX;

    public GameStateTransitionTo25d(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        GameObject _extazModeHolder = GameObject.Find("2D Extaz");
        Transform[] _extazHolderChildren = _extazModeHolder.transform.GetComponentsInChildren<Transform>();

		////Trying to add/remove the speedlines
		//GameObject.Find("ReferenceBody/MainCamera/Speedlines_Foreground").GetComponent<SpeedLines_Opacity>().AddSpeedLines();
		//GameObject.Find("GameManager/Speedlines_Background").GetComponent<SpeedLines_Opacity>().AddSpeedLines();

        foreach (Transform childTransform in _extazHolderChildren)
        {
            if (childTransform != _extazModeHolder.transform)
            {
                childTransform.gameObject.SetActive(false);
            }
        }

        //################################################

        playerInfos = gameManager.GetAllPlayerInfos();
        fromX = new float[3];
        toX = new float[3];
        UI _uiScript = GameObject.Find("UI").GetComponent<UI>();

        for (int i = 0; i < 3; i++)
        {
            PlayerInfo _info = playerInfos[i];

            if (_info.isDead)
            {
                _info.character.gameObject.SetActive(true);
                _info.isDead = true;
                _uiScript.GoWhite(_info.index);
            }

            fromX[i] = _info.character.transform.localPosition.x;
            toX[i] = _info.previous25dX;

            if (toX[i] == -10f)
            {
                toX[i] = 0;
            }

            Vector3 _charLocPos = _info.character.transform.localPosition;
            if (_info.currentLane == 0 && _charLocPos.z != -3f)
            {
                _charLocPos.z = -3f;
                _info.character.transform.localPosition = _charLocPos;
            }
            else if(_info.currentLane == 1 && _charLocPos.z != 0f)
            {
                _charLocPos.z = 0f;
                _info.character.transform.localPosition = _charLocPos;
            }
            else if (_info.currentLane == 2 && _charLocPos.z != 3f)
            {
                _charLocPos.z = 3f;
                _info.character.transform.localPosition = _charLocPos;
            }
        }

        //################################################

        stateTimer = 0f;
        gameManager.cameraManager.StartTransition(transitionTo25dPosition, transitionTo25dRotation, transitionTo25dSize, transitionTo25dTime);
    }

    protected override void OnExit()
    {
        GameObject _brawlModeHolder = GameObject.Find("2.5D Brawl");
        Transform[] _brawlHolderChildren = _brawlModeHolder.transform.GetComponentsInChildren<Transform>(true);

		//Trying to add/remove the speedlines
		//GameObject.Find("ReferenceBody/MainCamera/Speedlines_Foreground").GetComponent<SpeedLines_Opacity>().RemoveSpeedLines();
		//GameObject.Find("GameManager/Speedlines_Background").GetComponent<SpeedLines_Opacity>().RemoveSpeedLines();

        foreach (Transform childTransform in _brawlHolderChildren)
        {
            if (childTransform != _brawlModeHolder.transform)
            {
                if(childTransform.GetComponent<BoxCollider>() == null && childTransform.tag != "FX")
                {
                    childTransform.gameObject.SetActive(true);
                }
                else if (childTransform.localPosition.x >= gameManager.cameraManager.transform.position.x + 10f)
                {
                    childTransform.gameObject.SetActive(true);
                }
            }
        }

        GameObject _habillageHolder = GameObject.Find("Habillage level");

        foreach (Transform childTransform in _habillageHolder.transform.GetComponentsInChildren<Transform>(true))
        {
            if (childTransform.tag == "Brawl mode obstacles")
            {
                childTransform.gameObject.SetActive(true);
            }
        }

        /*GameObject[] _brawlModeObstacles = GameObject.FindGameObjectsWithTag("Brawl mode obstacles");
        float _xLimit = gameManager.cameraManager.transform.position.x + 5f;
        foreach (GameObject brawlObstacle in _brawlModeObstacles)
        {
            if (brawlObstacle.transform.position.x >= _xLimit)
            {
                brawlObstacle.SetActive(true);
            }
        }

        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in _enemies)
        {
            enemy.SetActive(true);
        }*/

        for (int i = 0; i < 3; i++)
        {
            PlayerInfo _playerInfo = gameManager.GetPlayerInfo(i);

            _playerInfo.isDead = false;
        }
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
    }

    protected override void OnUpdate()
    {
        stateTimer += Time.deltaTime;

        if (stateTimer > transitionTo25dTime)
        {
            gameManager.SwitchState(new GameState25d(gameManager));
        }


        float _positioningProgress = stateTimer / transitionTo25dTime;

        float _firstX = Mathf.SmoothStep(fromX[0], toX[0], _positioningProgress);
        float _secondX = Mathf.SmoothStep(fromX[1], toX[1], _positioningProgress);
        float _thirdX = Mathf.SmoothStep(fromX[2], toX[2], _positioningProgress);

        Vector3 _firstPos = playerInfos[0].character.transform.localPosition;
        Vector3 _secondPos = playerInfos[1].character.transform.localPosition;
        Vector3 _thirdPos = playerInfos[2].character.transform.localPosition;

        playerInfos[0].character.transform.localPosition = new Vector3(_firstX, _firstPos.y, _firstPos.z);
        playerInfos[1].character.transform.localPosition = new Vector3(_secondX, _secondPos.y, _secondPos.z);
        playerInfos[2].character.transform.localPosition = new Vector3(_thirdX, _thirdPos.y, _thirdPos.z);
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
    }

    protected override void OnButtonPressed(string buttonName)
    {
    }
}
