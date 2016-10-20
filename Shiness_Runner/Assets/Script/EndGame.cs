using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

    GameManager _gm;
	
	void OnTriggerEnter(Collider col)
    {
        _gm = FindObjectOfType<GameManager>();
        _gm.SwitchState(new GameStateEndGame(_gm));
    }
}
