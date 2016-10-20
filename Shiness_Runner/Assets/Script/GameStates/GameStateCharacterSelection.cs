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
        GameObject.Find("ReferenceBody").GetComponent<ReferenceBodyController>().ChangeSpeed(0f);

        GameObject.Find("UI").SetActive(true);
        GameObject.Find("CharacterSelectionCanvas").SetActive(true);
    }

    protected override void OnExit()
    {
        GameObject.Find("UI").SetActive(false);
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
}
