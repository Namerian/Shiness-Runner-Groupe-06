using UnityEngine;
using System.Collections;

public class JoystickState
{
    public int characterIndex { get; private set; }

    public bool buttonA_down { get; private set; }
    public bool buttonA_up { get; private set; }

    public bool buttonY_down { get; private set; }
    public bool buttonY_up { get; private set; }

    public bool buttonB_down { get; private set; }
    public bool buttonB_up { get; private set; }

    public bool yAxisUp { get; private set; }
    public bool yAxisDown { get; private set; }

    public JoystickState(int characterIndex, bool buttonA_down, bool buttonA_up, bool buttonY_down, bool buttonY_up, bool buttonB_down, bool buttonB_up, bool yAxisUp, bool yAxisDown)
    {
        this.characterIndex = characterIndex;

        this.buttonA_down = buttonA_down;
        this.buttonA_up = buttonA_up;

        this.buttonY_down = buttonY_down;
        this.buttonY_up = buttonY_up;

        this.buttonB_down = buttonB_down;
        this.buttonB_up = buttonB_up;

        this.yAxisUp = yAxisUp;
        this.yAxisDown = yAxisDown;
    }
}
