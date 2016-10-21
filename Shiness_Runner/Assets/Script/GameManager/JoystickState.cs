using UnityEngine;
using System.Collections;

public class JoystickState
{
    public PlayerInfo playerInfo { get; private set; }

    public bool buttonA_down { get; private set; }
    public bool buttonA_up { get; private set; }

    public bool buttonB_down { get; private set; }
    public bool buttonB_up { get; private set; }

    public bool buttonX_down { get; private set; }

    public bool yAxisUp { get; private set; }
    public bool yAxisDown { get; private set; }

    public bool axisLT { get; private set; }
    public bool axisRT { get; private set; }

    public JoystickState(
        PlayerInfo playerInfo,
        bool buttonA_down, bool buttonA_up,
        bool buttonB_down, bool buttonB_up,
        bool buttonX_down,
        bool yAxisUp, bool yAxisDown,
        bool axisLT, bool axisRT)
    {
        this.playerInfo = playerInfo;

        this.buttonA_down = buttonA_down;
        this.buttonA_up = buttonA_up;

        this.buttonB_down = buttonB_down;
        this.buttonB_up = buttonB_up;

        this.buttonX_down = buttonX_down;

        this.yAxisUp = yAxisUp;
        this.yAxisDown = yAxisDown;

        this.axisLT = axisLT;
        this.axisRT = axisRT;
    }
}
