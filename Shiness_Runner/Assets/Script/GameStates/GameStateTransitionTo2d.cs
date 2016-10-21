using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class GameStateTransitionTo2d : GameState
{
    private Vector3 transitionTo2DPosition = new Vector3(1.25f, 1.25f, -8f);
    private Vector3 transitionTo2DRotation = new Vector3(0f, 0f, 0f);
    private const float transitionTo2dSize = 2.5f;
    private const float transitionTo2dTime = 0.2f;

    private float stateTimer;

    private PlayerInfo firstCharacter;
    private float firstFromX, firstToX;

    private PlayerInfo secondCharacter;
    private float secondFromX, secondToX;

    private PlayerInfo thirdCharacter;
    private float thirdFromX, thirdToX;

    public GameStateTransitionTo2d(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        Debug.Log("GameStateTransitionTo2d: OnEnter: called");

        GameObject _brawlModeHolder = GameObject.Find("2.5D Brawl");
        
        foreach (Transform childTransform in _brawlModeHolder.transform.GetComponentsInChildren<Transform>())
        {
            if (childTransform != _brawlModeHolder.transform)
            {
                childTransform.gameObject.SetActive(false);
            }
        }

        GameObject _habillageHolder = GameObject.Find("Habillage level");

        foreach(Transform childTransform in _habillageHolder.transform.GetComponentsInChildren<Transform>())
        {
            
                childTransform.gameObject.SetActive(false);
            
        }

        //################################################

        PlayerInfo[] _playerInfos = gameManager.GetAllPlayerInfos();
        UI _uiScript = GameObject.Find("UI").GetComponent<UI>();

        foreach (PlayerInfo info in _playerInfos)
        {
            if (info.isDead)
            {
                Vector3 _charPos = info.character.transform.localPosition;
                info.character.transform.localPosition = new Vector3(-10f, _charPos.y, _charPos.z);

                info.character.gameObject.SetActive(true);
                info.isDead = false;
                info.previous25dX = -10f;
                _uiScript.GoWhite(info.index);
            }
            else
            {
                info.previous25dX = info.character.transform.localPosition.x;
            }
        }

        //################################################

        firstToX = 0f;
        secondToX = -1f;
        thirdToX = -2f;

        List<PlayerInfo> _unsortedPlayerInfos = new List<PlayerInfo>(_playerInfos);
        List<PlayerInfo> _sortedPlayerInfos = new List<PlayerInfo>();

        while (_unsortedPlayerInfos.Count > 0)
        {
            float _bestX = -100;
            List<PlayerInfo> _bestPlayerInfos = new List<PlayerInfo>();

            foreach (PlayerInfo info in _unsortedPlayerInfos)
            {
                if (info.previous25dX > _bestX)
                {
                    _bestPlayerInfos.Clear();
                    _bestPlayerInfos.Add(info);
                    _bestX = info.previous25dX;
                }
                else if (info.previous25dX == _bestX)
                {
                    _bestPlayerInfos.Add(info);
                }
            }

            foreach (PlayerInfo info in _bestPlayerInfos)
            {
                _unsortedPlayerInfos.Remove(info);
                _sortedPlayerInfos.Add(info);
            }
        }

        firstCharacter = _sortedPlayerInfos[0];
        secondCharacter = _sortedPlayerInfos[1];
        thirdCharacter = _sortedPlayerInfos[2];

        firstFromX = firstCharacter.previous25dX;
        secondFromX = secondCharacter.previous25dX;
        thirdFromX = thirdCharacter.previous25dX;

        //################################################

        stateTimer = 0f;
        //gameManager.cameraManager.StartTransition(transitionTo2DPosition, transitionTo2DRotation, transitionTo2dSize, transitionTo2dTime);
        gameManager.cameraManager.transform.DOLocalMove(transitionTo2DPosition, transitionTo2dTime);
        gameManager.cameraManager.transform.DOLocalRotate(transitionTo2DRotation, transitionTo2dTime);
        Camera.main.DOOrthoSize(transitionTo2dSize, transitionTo2dTime);
    }

    protected override void OnExit()
    {
        Debug.Log("GameStateTransitionTo2d: OnExit: called");

        GameObject _extazModeHolder = GameObject.Find("2D Extaz");

        foreach (Transform childTransform in _extazModeHolder.transform.GetComponentsInChildren<Transform>(true))
        {
            if (childTransform != _extazModeHolder.transform)
            {
                if (childTransform.GetComponent<BoxCollider>() == null && childTransform.tag != "FX")
                {
                    childTransform.gameObject.SetActive(true);
                }
                else if (childTransform.localPosition.x >= gameManager.cameraManager.transform.position.x + 10)
                {
                    childTransform.gameObject.SetActive(true);
                }
            }
        }
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
    }

    protected override void OnUpdate()
    {
        stateTimer += Time.deltaTime;

        if (stateTimer > transitionTo2dTime + 0.05f)
        {
            gameManager.SwitchState(new GameState2d(gameManager));
        }

        if (stateTimer > 0.05f)
        {
            float _positioningProgress = (stateTimer-0.05f) / (transitionTo2dTime-0.05f);

            float _firstX = Mathf.SmoothStep(firstFromX, firstToX, _positioningProgress);
            float _secondX = Mathf.SmoothStep(secondFromX, secondToX, _positioningProgress);
            float _thirdX = Mathf.SmoothStep(thirdFromX, thirdToX, _positioningProgress);

            Vector3 _firstPos = firstCharacter.character.transform.localPosition;
            Vector3 _secondPos = secondCharacter.character.transform.localPosition;
            Vector3 _thirdPos = thirdCharacter.character.transform.localPosition;

            firstCharacter.character.transform.localPosition = new Vector3(_firstX, _firstPos.y, _firstPos.z);
            secondCharacter.character.transform.localPosition = new Vector3(_secondX, _secondPos.y, _secondPos.z);
            thirdCharacter.character.transform.localPosition = new Vector3(_thirdX, _thirdPos.y, _thirdPos.z);
        }
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
    }

    protected override void OnButtonPressed(string buttonName)
    {
    }
}
