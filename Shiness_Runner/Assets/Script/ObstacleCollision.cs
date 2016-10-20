﻿using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour {

    public bool brawlMode;

    Rigidbody _rb;
    GameManager _gm;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && brawlMode)
        {
            _rb = col.gameObject.GetComponent<Rigidbody>();
            if (_rb.velocity.x == 0)
            {
                _rb.velocity -= new Vector3(2, 1, 0);
                Debug.Log("ho");
                _gm.Extase -= 5;
                _gm.uicanvas.GetComponent<UI>().HitShake(col.gameObject.name);
            }
        }else
        if(col.gameObject.tag == "Player" && !brawlMode)
        {
            if(tag == "Enemy")
            {
                Destroy(gameObject);
            }else
            {
                //_gm.heroDied(col.gameObject.GetComponent<HeroController>());
            }
        }
    }
}
