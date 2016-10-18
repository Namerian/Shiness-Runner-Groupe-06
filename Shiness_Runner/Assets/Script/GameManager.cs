using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private string[] joystickNames;
    private HeroController[] characters;

	// Use this for initialization
	void Start () {

        joystickNames = Input.GetJoystickNames();

        Debug.Log("There are " + joystickNames.Length + " Joysticks available.");

        characters = new HeroController[joystickNames.Length];

        for(int i = 0; i < joystickNames.Length; i++)
        {
            characters[i] = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            characters[0].Jump();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            characters[0].StartMove();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            characters[0].StopMove();
        }

        //HandleInput();
	}

    private void HandleInput()
    {
        
    }

    private void HandleCharacterInput(int charId)
    {
        string joystickName = joystickNames[charId];
        HeroController character = characters[charId];

        if (Input.GetButtonDown("Joy" + charId + "Jump"))
        {

        }
    }
}
