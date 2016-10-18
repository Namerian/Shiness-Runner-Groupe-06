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
            characters[0] = GameObject.Find("Character" + (i + 1)).GetComponent<HeroController>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Joystick 0: Jump pressed");
        }

        /*if (Input.GetKeyDown(KeyCode.A))
        {
            character_1.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            character_2.Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            character_3.Jump();
        }*/
    }
}
