using UnityEngine;
using System.Collections;
using System;

public class GameStateCharacterSelection : GameState
{
    private CharacterSelectionController selectionController;

    private bool[] activeJoysticks;
    private HeroController[] characters;

    int currentJoystick;
    int currentCharacter;
    bool[] selectedCharacters;

    bool canChangeSelection;
    float selectionTimer;

    public GameStateCharacterSelection(GameManager gameManager) : base(gameManager)
    {
    }

    protected override void OnEnter()
    {
        GameObject.Find("ReferenceBody").GetComponent<ReferenceBodyController>().ChangeSpeed(0f);

        selectionController = GameObject.Find("UI").transform.FindChild("CharacterSelection").GetComponent<CharacterSelectionController>();
        selectionController.gameObject.SetActive(true);

        selectedCharacters = new bool[] { false, false, false };
        characters = new HeroController[3];



        string[] _joysticknames = Input.GetJoystickNames();
        activeJoysticks = new bool[] { false, false, false };

        /*foreach (string name in _joysticknames)
        {
            Debug.Log("joystickname: " + name);
        }*/

        for (int i = 0; i < 3; i++)
        {
            if (i < _joysticknames.Length && _joysticknames[i] != "")
            {
                //Debug.Log("active joystick recognized, index=" + i);
                activeJoysticks[i] = true;
            }
            else
            {
                break;
            }
        }

        characters[0] = GameObject.Find("ReferenceBody/Character1").GetComponent<HeroController>();
        characters[1] = GameObject.Find("ReferenceBody/Character2").GetComponent<HeroController>();
        characters[2] = GameObject.Find("ReferenceBody/Character3").GetComponent<HeroController>();

        currentJoystick = 0;
        currentCharacter = 0;
        selectionController.HighlightCharacter(true, currentCharacter);
        selectionController.SetCurrentPlayerText("Player 1");

        selectionController.GoWhite(0);
        selectionController.GoWhite(1);
        selectionController.GoWhite(2);

        canChangeSelection = true;
    }

    protected override void OnExit()
    {
        selectionController.gameObject.SetActive(false);
    }

    protected override void OnHandleInput(JoystickState[] joystickStates)
    {
        //Debug.Log("current Joystick:" + currentJoystick);
        //Debug.Log("num of joystickstates:" + joystickStates.Length);
        JoystickState _activeJoystick = joystickStates[currentJoystick];
        //Debug.Log("charSel: joyName= " + activeJoysticks[currentJoystick]);

        //
        if (activeJoysticks[currentJoystick] == false || _activeJoystick.buttonA_down)
        {
            //Debug.Log("Character selected: " + currentCharacter);
            gameManager.SetPlayerInfo(currentJoystick, new PlayerInfo(characters[currentCharacter], activeJoysticks[currentJoystick], currentJoystick, currentCharacter, currentCharacter));

            selectedCharacters[currentCharacter] = true;
            selectionController.HighlightCharacter(false, currentCharacter);
            selectionController.GoGrey(currentCharacter);
            currentJoystick += 1;
            selectionController.SetCurrentPlayerText("Player " + (currentJoystick + 1));

            if (currentJoystick >= 3)
            {
                gameManager.SwitchState(new GameState25d(gameManager));
                return;
            }

            for (int i = 0; i < 3; i++)
            {
                if (!selectedCharacters[i])
                {
                    currentCharacter = i;
                    selectionController.HighlightCharacter(true, currentCharacter);
                    break;
                }
            }
        }

        //######################################
        bool selectionChanged = false;
        if (canChangeSelection)
        {
            if (_activeJoystick.yAxisUp)
            {
                if (currentCharacter == 0)
                {
                    if (!selectedCharacters[1])
                    {
                        selectionController.HighlightCharacter(false, 0);
                        selectionController.HighlightCharacter(true, 1);
                        currentCharacter = 1;
                        selectionChanged = true;
                    }
                    else if (!selectedCharacters[2])
                    {
                        selectionController.HighlightCharacter(false, 0);
                        selectionController.HighlightCharacter(true, 2);
                        currentCharacter = 2;
                        selectionChanged = true;
                    }
                }
                else if (currentCharacter == 1)
                {
                    if (!selectedCharacters[2])
                    {
                        selectionController.HighlightCharacter(false, 1);
                        selectionController.HighlightCharacter(true, 2);
                        currentCharacter = 2;
                        selectionChanged = true;
                    }
                }
            }
            else if (_activeJoystick.yAxisDown)
            {
                if (currentCharacter == 2)
                {
                    if (!selectedCharacters[1])
                    {
                        selectionController.HighlightCharacter(false, 2);
                        selectionController.HighlightCharacter(true, 1);
                        currentCharacter = 1;
                        selectionChanged = true;
                    }
                    else if (!selectedCharacters[0])
                    {
                        selectionController.HighlightCharacter(false, 2);
                        selectionController.HighlightCharacter(true, 0);
                        currentCharacter = 0;
                        selectionChanged = true;
                    }
                }
                else if (currentCharacter == 1)
                {
                    if (!selectedCharacters[0])
                    {
                        selectionController.HighlightCharacter(false, 1);
                        selectionController.HighlightCharacter(true, 0);
                        currentCharacter = 0;
                        selectionChanged = true;
                    }
                }
            }
        }

        if (selectionChanged)
        {
            canChangeSelection = false;
            selectionTimer = 0f;
        }
    }

    protected override void OnPlayerDied(PlayerInfo player)
    {
    }

    protected override void OnUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            gameManager.SwitchState(new GameState25d(gameManager));
        }*/

        if (!canChangeSelection)
        {
            selectionTimer += Time.deltaTime;

            if (selectionTimer >= 0.2f)
            {
                canChangeSelection = true;
            }
        }
    }

    protected override void OnButtonPressed(string buttonName)
    {
    }
}
