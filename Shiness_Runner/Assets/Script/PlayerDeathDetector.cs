using UnityEngine;
using DG.Tweening;
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
                gameManager.PlayerDied(_otherGameObject.GetComponent<HeroController>());

                _otherGameObject.GetComponent<HeroController>().GetComponent<WindAttack>().cooldownFeedback.value = 0;

                gameManager.uicanvas.GetComponent<UI>().GoGrey(0);

                Camera.main.transform.DOShakePosition(0.5f, 0.25f, 20, 90);

                Debug.Log("Character1 died");
            }
            else if(_otherGameObject.name == "Character2")
            {
                gameManager.PlayerDied(_otherGameObject.GetComponent<HeroController>());

                _otherGameObject.GetComponent<HeroController>().GetComponent<LightAttack>().cooldownFeedback.value = 0;

                Camera.main.transform.DOShakePosition(0.5f, 0.25f, 20, 90);

                gameManager.uicanvas.GetComponent<UI>().GoGrey(1);

                Debug.Log("Character2 died");
            }
            else if (_otherGameObject.name == "Character3")
            {
                gameManager.PlayerDied(_otherGameObject.GetComponent<HeroController>());

                _otherGameObject.GetComponent<HeroController>().GetComponent<HeadButt>().cooldownFeedback.value = 0;

                Camera.main.transform.DOShakePosition(0.5f, 0.25f, 20, 90);

                gameManager.uicanvas.GetComponent<UI>().GoGrey(2);

                Debug.Log("Character3 died");
            }
        }
    }
}
