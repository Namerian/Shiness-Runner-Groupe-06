using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private string[] joystickNames;
    private HeroController[] characters;

    private GameState currentState;

	// Use this for initialization
	void Start () {

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
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            foreach(HeroController character in characters)
            {
                character.Jump();
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            foreach (HeroController character in characters)
            {
                character.StartMove();
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            foreach (HeroController character in characters)
            {
                character.StopMove();
            }
        }
	}

    public void SwitchState(GameState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;
        currentState.Enter();
    }
}
