using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private string[] joystickNames;
    public HeroController[] characters { get; private set; }
    public CameraManager cameraManager { get; private set; }

    public int[] lanes { get; private set; } //this represents the lines (going up), the values are the indexes of the characters in their array

    private GameState currentState;

    private JoystickState[] previousJoystickStates;

    //#################################################
    // Use this for initialization
    //#################################################
    void Start()
    {
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();

        string[] _joysticks = Input.GetJoystickNames();
        Debug.Log("There are " + _joysticks.Length + " Joysticks available.");
        joystickNames = new string[3];

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
        }

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
            foreach (HeroController character in characters)
            {
                character.Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            foreach (HeroController character in characters)
            {
                character.SlideStart();
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            foreach (HeroController character in characters)
            {
                character.SlideStop();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (HeroController character in characters)
            {
                // character.StartMove();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (HeroController character in characters)
            {
                //character.StopMove();
            }
        }

        //#################################################

        JoystickState[] _joystickStates = new JoystickState[characters.Length];

        for (int i = 0; i < characters.Length; i++)
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

            if (joystickNames[i] != null && joystickNames[i] != "")
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

                if (axisY_pos > 0 && !_YAxisUp_previous)
                {
                    _YAxisUp = true;
                }
                else if (axisY_pos < 0 && !_YAxisDown_previous)
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
}

public class GameManager : MonoBehaviour
{
	private string[] joystickNames;
	public HeroController[] characters { get; private set; }

	public CameraManager cameraManager { get; private set; }


	private GameState currentState;

	private JoystickState[] previousJoystickStates;

    //#################################################
    // Use this for initialization
    //#################################################
    void Start ()
	{
		cameraManager = GameObject.Find ("MainCamera").GetComponent<CameraManager> ();

        string[] _joysticks = Input.GetJoystickNames();
        joystickNames = new string[3];

        for(int i = 0; i < 3; i++)
        {
            if(_joysticks.Length > i && _joysticks[i] != null && _joysticks[i] != "")
            {
                joystickNames[i] = _joysticks[i];
            }
            else
            {
                joystickNames[i] = "";
                Debug.LogError("No Controller for Player " + (i + 1) + "!");
            }
        }

		Debug.Log ("There are " + joystickNames.Length + " Joysticks available.");

		//characters = new HeroController[joystickNames.Length];
		characters = new HeroController[3];

		//for(int i = 0; i < joystickNames.Length; i++)
		for (int i = 0; i < 3; i++) {
			characters [i] = GameObject.Find ("Character" + (i + 1)).GetComponent<HeroController> ();
		}

		currentState = new GameState25d (this);
		currentState.Enter ();
	}

    //#################################################
    // Update is called once per frame
    //#################################################
    void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (HeroController character in characters) {
				character.Jump ();
			}
		}

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach (HeroController character in characters)
            {
                character.JumpCancel();
            }
        }

        if (Input.GetKeyDown (KeyCode.LeftControl)) {
			foreach (HeroController character in characters) {
				character.SlideStart ();
			}
		}

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            foreach (HeroController character in characters)
            {
                character.SlideStop();
            }
        }

        if (Input.GetKeyDown (KeyCode.A)) {
			foreach (HeroController character in characters) {
				// character.StartMove();
			}
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			foreach (HeroController character in characters) {
				//character.StopMove();
			}
		}

		//#################################################

		JoystickState[] _joystickStates = new JoystickState[characters.Length];

		for (int i = 0; i < characters.Length; i++) {
			bool _buttonA, _buttonY, _buttonB, _YAxisUp, _YAxisDown, _YAxisUp_previous, _YAxisDown_previous;
			float y;

			_buttonA = _buttonY = _buttonB = _YAxisUp = _YAxisDown = _YAxisUp_previous = _YAxisDown_previous = false;

			if (previousJoystickStates != null) {
				_YAxisUp_previous = previousJoystickStates [i].YAxisUp;
				_YAxisDown_previous = previousJoystickStates [i].YAxisDown;
			}

            if (joystickNames[i] != null && joystickNames[i] != "")
            {
                if (Input.GetKeyDown("joystick " + (i + 1) + " button 0"))
                {
                    _buttonA = true;
                    Debug.Log("joystick " + i + ": A pressed");
                }

                if (Input.GetKeyDown("joystick " + (i + 1) + " button 3"))
                {
                    _buttonY = true;
                }

                if (Input.GetKeyDown("joystick " + (i + 1) + " button 1"))
                {
                    _buttonB = true;
                }

                y = Input.GetAxis("Joy1_Vertical");

                if (y > 0 && !_YAxisUp_previous)
                {
                    _YAxisUp = true;
                }
                else if (y < 0 && !_YAxisDown_previous)
                {
                    _YAxisDown = true;
                }
            }

			_joystickStates [i] = new JoystickState (i, _buttonA, _buttonY, _buttonB, _YAxisUp, _YAxisDown);
		}

		currentState.HandleInput (_joystickStates);
		previousJoystickStates = _joystickStates;

		//#################################################

		currentState.Update ();
	}

    //#################################################
    //
    //#################################################
    public void SwitchState (GameState newState)
	{
		if (currentState != null) {
			currentState.Exit ();
		}

		currentState = newState;
		currentState.Enter ();
	}
}
