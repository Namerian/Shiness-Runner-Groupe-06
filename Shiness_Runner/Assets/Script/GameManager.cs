using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private PlayerInfo[] playerInfoArray;

    public CameraManager cameraManager { get; private set; }

    private Slider extaseSliderView;

    private GameState currentState;

    private float extase;

    private JoystickState[] previousJoystickStates;

    public float extasePerSecond;

    public Canvas uicanvas;

    private float scoreMultiplier;

    public float enemyBatScoreValue;
    public float enemyGolemScoreValue;
    public float enemyEssaimScoreValue;

    //#################################################

    public float Extase
    {
        get { return extase; }
        set
        {
            if (value < 0)
            {
                extase = 0;
            }
            else if (value > 100)
            {
                extase = 100;
            }
            else
            {
                extase = value;
            }

            extaseSliderView.value = extase;
        }
    }

    public float ScoreMultiplier
    {
        get { return scoreMultiplier; }
        set
        {
            scoreMultiplier = value;
        }
    }

    //#################################################
    // Use this for initialization
    //#################################################
    void Start()
    {
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
        extaseSliderView = GameObject.Find("UI/ExtaseBarUI/ExtaseSlider").GetComponent<Slider>();
        uicanvas = GameObject.Find("UI").GetComponent<Canvas>();

        playerInfoArray = new PlayerInfo[3];
        string[] _joysticks = Input.GetJoystickNames();

        for (int i = 0; i < 3; i++)
        {
            string _joystick = "";
            HeroController _character;

            if (_joysticks.Length > i && _joysticks[i] != null && _joysticks[i] != "")
            {
                _joystick = _joysticks[i];
            }

            _character = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();

            playerInfoArray[i] = new PlayerInfo(_character, _joystick, i, i);
        }

        //#################################################

        GameObject _extazModeHolder = GameObject.Find("2D Extaz");
        Transform[] _extazHolderChildren = _extazModeHolder.transform.GetComponentsInChildren<Transform>();
        Debug.Log("GameStateTransitionTo25d: OnEnter: " + _extazHolderChildren.Length + " objects to deactivate");

        foreach (Transform childTransform in _extazHolderChildren)
        {
            if (childTransform != _extazModeHolder.transform)
            {
                childTransform.gameObject.SetActive(false);
            }
        }

        //#################################################

        currentState = new GameState25d(this);
        currentState.Enter();
    }

    //#################################################
    // Update is called once per frame
    //#################################################
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (PlayerInfo info in playerInfoArray)
            {
                info.character.Jump();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (PlayerInfo info in playerInfoArray)
            {
                info.character.JumpCancel();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            foreach (PlayerInfo info in playerInfoArray)
            {
                info.character.SlideStart();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            foreach (PlayerInfo info in playerInfoArray)
            {
                info.character.SlideStop();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (PlayerInfo info in playerInfoArray)
            {
                info.character.Ability();
            }
        }

        //#################################################

        JoystickState[] _joystickStates = new JoystickState[3];

        for (int i = 0; i < 3; i++)
        {
            bool _buttonA_down = false;
            bool _buttonA_up = false;
            bool _buttonB_down = false;
            bool _buttonB_up = false;
            bool _buttonX_down = false;

            bool _YAxisUp = false;
            bool _YAxisDown = false;
            bool _YAxisUp_previous = false;
            bool _YAxisDown_previous = false;

            bool _axisLT = false;
            bool _axisRT = false;

            float _axisY_pos;
            float _axisLT_pos;
            float _axisRT_pos;

            if (previousJoystickStates != null)
            {
                _YAxisUp_previous = previousJoystickStates[i].yAxisUp;
                _YAxisDown_previous = previousJoystickStates[i].yAxisDown;
            }

            if (playerInfoArray[i].joystick != "")
            {
                //button A
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 0"))
                {
                    _buttonA_down = true;
                }
                else if (Input.GetKeyUp("joystick " + (i + 1) + " button 0"))
                {
                    _buttonA_up = true;
                }

                //button B
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 1"))
                {
                    _buttonB_down = true;
                }
                else if (Input.GetKeyUp("joystick " + (i + 1) + " button 1"))
                {
                    _buttonB_up = true;
                }

                //button X
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 2"))
                {
                    _buttonX_down = true;
                }

                //axis Y
                _axisY_pos = Input.GetAxis("Joy"+(i+1)+"_Yaxis");

                if (_axisY_pos < 0 && !_YAxisUp_previous)
                {
                    _YAxisUp = true;
                }
                else if (_axisY_pos > 0 && !_YAxisDown_previous)
                {
                    _YAxisDown = true;
                }

                //axis LT
                _axisLT_pos = Input.GetAxis("Joy" + (i + 1) + "_LT");

                if(_axisLT_pos > 0)
                {
                    _axisLT = true;
                }

                //axis RT
                _axisRT_pos = Input.GetAxis("Joy" + (i + 1) + "_RT");

                if(_axisRT_pos > 0)
                {
                    _axisRT = true;
                }
            }

            _joystickStates[i] = new JoystickState(i, _buttonA_down, _buttonA_up, _buttonB_down, _buttonB_up, _buttonX_down, _YAxisUp, _YAxisDown, _axisLT, _axisRT);
        }

        currentState.HandleInput(_joystickStates);
        previousJoystickStates = _joystickStates;

        //#################################################

        currentState.Update();

        //#################################################
        
        foreach(PlayerInfo info in playerInfoArray)
        {
            if (!info.isDead)
            {
                info.score += Time.deltaTime;
            }
        }
    }

    //#################################################
    //
    //#################################################
    public void SwitchState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }

    //#################################################
    //
    //#################################################
    public void PlayerDied(HeroController hero)
    {
        foreach(PlayerInfo info in playerInfoArray)
        {
            if(hero == info.character)
            {
                currentState.PlayerDied(info);
                return;
            }
        }

        Debug.LogError("GameManager: PlayerDied: unknown hero died (" + hero.gameObject.name + ")");
    }

    //#################################################
    //
    //#################################################
    public PlayerInfo GetPlayerInfo(int index)
    {
        if (index >= 0 && index < 3)
        {
            return playerInfoArray[index];
        }

        Debug.Log("GamaManager: GetPlayerInfo: fail! index=" + index);
        return null;
    }

    //#################################################
    //
    //#################################################
    public PlayerInfo[] GetAllPlayerInfos()
    {
        PlayerInfo[] _array = new PlayerInfo[3];
        for (int i = 0; i < 3; i++)
        {
            _array[i] = playerInfoArray[i];
        }

        return _array;
    }

    //#################################################
    //
    //#################################################
    public void AddScore(float score, HeroController hero)
    {
        PlayerInfo _info = null;

        foreach(PlayerInfo info in playerInfoArray)
        {
            if(hero == info.character)
            {
                _info = info;
                break;
            }
        }

        float _newScore = _info.score + (scoreMultiplier * score);

        _info.score = _newScore;
    }
}