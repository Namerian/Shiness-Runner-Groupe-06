﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	private string[] joystickNames;
	private HeroController[] characters;

	private CameraManager cameraManager;
    

	private GameState currentState;

	private JoystickState[] previousJoystickStates;

	//#################################################

	// Use this for initialization
	void Start ()
	{
		cameraManager = GameObject.Find ("MainCamera").GetComponent<CameraManager> ();

		joystickNames = Input.GetJoystickNames ();

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

	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Space)) {
			foreach (HeroController character in characters) {
				character.Jump ();
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

		if (Input.GetKeyDown (KeyCode.T)) { // transition to 2D
			cameraManager.StartTransition (new Vector3 (1.25f, 8f, -30f), new Vector3 (0, 0, 0), 2.5f, 1.5f);
		} else if (Input.GetKeyDown (KeyCode.Y)) { // transition to 2.5D
			cameraManager.StartTransition (new Vector3 (15f, 60f, -25f), new Vector3 (35, 0, 0), 4.5f, 1.5f); // pos = 1.5,6.5,-7.5
		}

		//#################################################

		JoystickState[] _joystickStates = new JoystickState[joystickNames.Length];

		for (int i = 0; i < joystickNames.Length; i++) {
			bool _buttonA, _buttonY, _buttonB, _YAxisUp, _YAxisDown, _YAxisUp_previous, _YAxisDown_previous;
			float y;

			_buttonA = _buttonY = _buttonB = _YAxisUp = _YAxisDown = _YAxisUp_previous = _YAxisDown_previous = false;

			if (previousJoystickStates != null) {
				_YAxisUp_previous = previousJoystickStates [i].YAxisUp;
				_YAxisDown_previous = previousJoystickStates [i].YAxisDown;
			}


			if (Input.GetKeyDown ("joystick " + (i + 1) + " button 0")) {
				_buttonA = true;
				Debug.Log ("joystick " + i + ": A pressed");
			}

			if (Input.GetKeyDown ("joystick " + (i + 1) + " button 3")) {
				_buttonY = true;
			}

			if (Input.GetKeyDown ("joystick " + (i + 1) + " button 1")) {
				_buttonB = true;
			}

			y = Input.GetAxis ("Joy1_Vertical");

			if (y > 0 && !_YAxisUp_previous) {
				_YAxisUp = true;
			} else if (y < 0 && !_YAxisDown_previous) {
				_YAxisDown = true;
			}

			_joystickStates [i] = new JoystickState (i, _buttonA, _buttonY, _buttonB, _YAxisUp, _YAxisDown);
		}

		currentState.HandleInput (_joystickStates);
		previousJoystickStates = _joystickStates;
	}

	public void SwitchState (GameState newState)
	{
		if (currentState != null) {
			currentState.Exit ();
		}

		currentState = newState;
		currentState.Enter ();
	}
}
