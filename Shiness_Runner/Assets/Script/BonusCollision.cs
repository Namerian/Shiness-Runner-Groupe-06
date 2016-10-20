using UnityEngine;
using System.Collections;

public class BonusCollision : MonoBehaviour {

    public float extazBonusValue = 5;
    GameManager _gm;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _gm.Extase += extazBonusValue;
        }
    }
}
