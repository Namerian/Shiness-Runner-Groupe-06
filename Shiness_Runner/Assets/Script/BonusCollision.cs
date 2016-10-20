using UnityEngine;
using System.Collections;
using DG.Tweening;

public class BonusCollision : MonoBehaviour {

    public float extazBonusValue = 5;
    public float scaleMaxValue = 1.1f;
    public float scaleMinValue = 0.9f;
    GameManager _gm;

    void Start()
    {
        transform.DOScaleX(scaleMaxValue, 1);
        transform.DOScaleY(scaleMaxValue, 1);
        transform.DOScaleZ(scaleMaxValue, 1);
        _gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(transform.localScale.x == scaleMaxValue)
        {
            BreathOut();
        }

        if (transform.localScale.x == scaleMinValue)
        {
            BreathIn();
        }
    }

    void BreathIn()
    {
        transform.DOScaleX(scaleMaxValue, 1);
        transform.DOScaleY(scaleMaxValue, 1);
        transform.DOScaleZ(scaleMaxValue, 1);
    }

    void BreathOut()
    {
        transform.DOScaleX(scaleMinValue, 1);
        transform.DOScaleY(scaleMinValue, 1);
        transform.DOScaleZ(scaleMinValue, 1);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _gm.Extase += extazBonusValue;
            Destroy(gameObject);
        }
    }
}
