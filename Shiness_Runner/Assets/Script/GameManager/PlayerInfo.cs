using UnityEngine;
using System.Collections;

public class PlayerInfo
{
    public HeroController character { get; private set; }

    public bool activeJoystick { get; private set; }

    public int joystickIndex { get; private set; }

    public int index { get; private set; }

    public int currentLane { get; set; }


    public bool isDead { get; set; }

    public float previous25dX { get; set; }

    public float score { get; set; }

    public PlayerInfo(HeroController character, bool activeJoystick, int joystickIndex, int index, int lane)
    {
        this.character = character;
        this.activeJoystick = activeJoystick;
        this.joystickIndex = joystickIndex;
        this.index = index;
        this.currentLane = lane;

        isDead = false;
        previous25dX = 0;
        score = 0f;
    }
}
