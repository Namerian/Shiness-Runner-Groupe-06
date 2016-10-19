using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //private string[] joystickNames;
    //public HeroController[] characters { get; private set; }

    private PlayerInfo[] playerInfoArray;

    public CameraManager cameraManager { get; private set; }
    private Slider extaseSliderView;

    public int[] lanes { get; private set; } //this represents the lines (going up), the values are the indexes of the characters in their array

    private GameState currentState;

    private float extase;

    private JoystickState[] previousJoystickStates;

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

    //#################################################
    // Use this for initialization
    //#################################################
    void Start()
    {
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
        extaseSliderView = GameObject.Find("UI/ExtaseBarUI/ExtaseSlider").GetComponent<Slider>();

        playerInfoArray = new PlayerInfo[3];
        string[] _joysticks = Input.GetJoystickNames();
        lanes = new int[3];

        for (int i = 0; i < 3; i++)
        {
            string _joystick = "";
            HeroController _character;

            if (_joysticks.Length > i && _joysticks[i] != null && _joysticks[i] != "")
            {
                _joystick = _joysticks[i];
            }

            _character = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();

            playerInfoArray[i] = new PlayerInfo(_character, _joystick);
            lanes[i] = i;
        }


        /////////////////////////////////////////////////////

        /*joystickNames = new string[3];

        for (int i = 0; i < 3; i++)
        {
            if (_joysticks.Length > i && _joysticks[i] != null && _joysticks[i] != "")
            {
                joystickNames[i] = _joysticks[i];
            }
            else
            {
                joystickNames[i] = "";
                Debug.LogError("No Controller for Player " + (i + 1) + "!");
            }
        }

        //characters = new HeroController[joystickNames.Length];
        characters = new HeroController[3];
        lanes = new int[3];

        //for(int i = 0; i < joystickNames.Length; i++)
        for (int i = 0; i < 3; i++)
        {
            characters[i] = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();
            lanes[i] = i;
        }*/

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

        //#################################################

        JoystickState[] _joystickStates = new JoystickState[3];

        for (int i = 0; i < 3; i++)
        {
            bool _buttonA_down = false;
            bool _buttonA_up = false;
            bool _buttonY_down = false;
            bool _buttonY_up = false;
            bool _buttonB_down = false;
            bool _buttonB_up = false;

            bool _YAxisUp = false;
            bool _YAxisDown = false;
            bool _YAxisUp_previous = false;
            bool _YAxisDown_previous = false;

            float axisY_pos;

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

                //button Y
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 3"))
                {
                    _buttonY_down = true;
                }
                else if (Input.GetKeyUp("joystick " + (i + 1) + " button 3"))
                {
                    _buttonY_up = true;
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

                //axis Y
                axisY_pos = Input.GetAxis("Joy1_Vertical");

                if (axisY_pos < 0 && !_YAxisUp_previous)
                {
                    _YAxisUp = true;
                }
                else if (axisY_pos > 0 && !_YAxisDown_previous)
                {
                    _YAxisDown = true;
                }
            }

            _joystickStates[i] = new JoystickState(i, _buttonA_down, _buttonA_up, _buttonY_down, _buttonY_up, _buttonB_down, _buttonB_up, _YAxisUp, _YAxisDown);
        }

        currentState.HandleInput(_joystickStates);
        previousJoystickStates = _joystickStates;

        //#################################################

        currentState.Update();
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
    public void SwitchLanes(int laneA, int laneB)
    {
        int charA = lanes[laneA];

        lanes[laneA] = lanes[laneB];

        lanes[laneB] = charA;
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
}