using UnityEngine;
using System.Collections;

public class PlayerInfo
{
    public HeroController character { get; private set; }

    public string joystick { get; private set; }

    public int index { get; private set; }

    public int currentLane { get; set; }


    public bool isDead { get; set; }

    public float previous25dX { get; set; }

    public float score { get; set; }

    public PlayerInfo(HeroController character, string joystick, int index, int lane)
    {
        this.character = character;
        this.joystick = joystick;
        this.index = index;
        this.currentLane = lane;

        isDead = false;
        previous25dX = 0;
        score = 0f;
    }
}
