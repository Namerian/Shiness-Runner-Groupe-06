using UnityEngine;
using System.Collections;

public class JoystickState
{
    public int CharacterIndex { get; private set; }

    public bool ButtonA { get; private set; }
    public bool ButtonY { get; private set; }
    public bool ButtonB { get; private set; }
    public bool YAxisUp { get; private set; }
    public bool YAxisDown { get; private set; }

    public JoystickState(int characterIndex, bool buttonA, bool buttonY, bool buttonB, bool yAxisUp, bool yAxisDown)
    {
        CharacterIndex = characterIndex;
        ButtonA = buttonA;
        ButtonY = buttonY;
        ButtonB = buttonB;
        YAxisUp = yAxisUp;
        YAxisDown = yAxisDown;
    }
}
