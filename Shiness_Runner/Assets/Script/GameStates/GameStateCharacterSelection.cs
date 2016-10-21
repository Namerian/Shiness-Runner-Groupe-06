using UnityEngine;
using System.Collections;
using System;

public class GameStateCharacterSelection : GameState
{
    public GameStateCharacterSelection(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        Debug.Log("GameStateCharacterSelection: OnEnter: called");

        GameObject.Find("ReferenceBody").GetComponent<ReferenceBodyController>().ChangeSpeed(0f);

        GameObject.Find("UI").transform.FindChild("CharacterSelection").gameObject.SetActive(true);
    }

    protected override void OnExit()
    {
        GameObject.Find("UI/CharacterSelection").SetActive(false);
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameManager.SwitchState(new GameState25d(gameManager));
        }
    }

    protected override void OnButtonPressed(string buttonName)
    {
    }
}
