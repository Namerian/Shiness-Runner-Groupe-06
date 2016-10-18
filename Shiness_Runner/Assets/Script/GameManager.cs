using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private string[] joystickNames;
    private HeroController[] characters;

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
