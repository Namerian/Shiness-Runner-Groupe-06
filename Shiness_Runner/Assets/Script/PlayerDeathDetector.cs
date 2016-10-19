using UnityEngine;
using System.Collections;

public class PlayerDeathDetector : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
