using UnityEngine;
using System.Collections;

public class PlayerInfo {

	public HeroController character { get; private set; }
    public string joystick { get; private set; }
    public int index { get; private set; }

    public bool isDead { get; set; }

    public PlayerInfo(HeroController character, string joystick, int index)
    {
        this.character = character;
        this.joystick = joystick;
        this.index = index;

        isDead = false;
    }
}
