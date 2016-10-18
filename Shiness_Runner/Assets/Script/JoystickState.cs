using UnityEngine;
using System.Collections;

public class JoystickState
{
    public int CharacterIndex { get; private set; }

    public bool ButtonA { get; private set; }
    public bool ButtonY { get; private set; }
    public bool ButtonB { get; private set; }

    public bool YAxisUp_current { get; private set; }
    public bool YAxisUp_previous { get; private set; }

    public JoystickState(int characterIndex, bool buttonA, bool buttonY, bool buttonB)
    {
        CharacterIndex = characterIndex;
        ButtonA = buttonA;
        ButtonY = buttonY;
        ButtonB = buttonB;
    }
}
