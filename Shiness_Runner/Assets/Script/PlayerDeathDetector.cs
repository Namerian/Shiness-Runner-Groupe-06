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

    void OnTriggerEnter(Collider otherCollider)
    {
        GameObject _otherGameObject = otherCollider.gameObject;

        if(_otherGameObject.tag == "Player")
        {
            if(_otherGameObject.name == "Character1")
            {
                gameManager.GetPlayerInfo(0).isDead = true;
                gameManager.uicanvas.GetComponent<UI>().GoGrey(0);
                Debug.Log("Character1 died");
            }
            else if(_otherGameObject.name == "Character2")
            {
                gameManager.GetPlayerInfo(1).isDead = true;
                gameManager.uicanvas.GetComponent<UI>().GoGrey(1);
                Debug.Log("Character2 died");
            }
            else if (_otherGameObject.name == "Character3")
            {
                gameManager.GetPlayerInfo(2).isDead = true;
                gameManager.uicanvas.GetComponent<UI>().GoGrey(2);
                Debug.Log("Character3 died");
            }
        }
    }
}
