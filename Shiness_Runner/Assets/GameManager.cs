using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //private HeroController character_1;
    //private HeroController character_2;
    //private HeroController character_3;

	// Use this for initialization
	void Start () {
        //character_1 = GameObject.Find("Character1").GetComponent<HeroController>();
        //character_2 = GameObject.Find("Character2").GetComponent<HeroController>();
        //character_3 = GameObject.Find("Character3").GetComponent<HeroController>();
	}
	
	// Update is called once per frame
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //character_1.Jump();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            //character_2.Jump();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //character_3.Jump();
        }
    }
}
