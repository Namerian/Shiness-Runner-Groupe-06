using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private string[] joystickNames;
    private HeroController[] characters;

    private GameState currentState;

    private JoystickState[] previousJoystickStates;

    // Use this for initialization
    void Start()
    {

        joystickNames = Input.GetJoystickNames();

        Debug.Log("There are " + joystickNames.Length + " Joysticks available.");

        //characters = new HeroController[joystickNames.Length];
        characters = new HeroController[3];

        //for(int i = 0; i < joystickNames.Length; i++)
        for (int i = 0; i < 3; i++)
        {
            characters[i] = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();
        }

        currentState = new GameState25d(this);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (HeroController character in characters)
            {
                character.Jump();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (HeroController character in characters)
            {
                character.StartMove();
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            foreach (HeroController character in characters)
            {
                character.StopMove();
            }
        }

        //#################################################

        JoystickState[] joystickStates = new JoystickState[joystickNames.Length];

        for(int i = 0; i < joystickNames.Length; i++)
        {
            bool buttonA, buttonY, buttonB, YAxisUp, YAxisDown;

            if (Input.GetKeyDown("joystick 1 button 0"))
            {
                Debug.Log("A pressed");
            }
        }

        if (Input.GetKeyDown("joystick 1 button 0"))
        {
            Debug.Log("A pressed");
        }

        float y = Input.GetAxis("Joy1_Vertical");
        if (y != 0)
        {
            Debug.Log("Axis: " + y);
        }
    }

    public void SwitchState(GameState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}
