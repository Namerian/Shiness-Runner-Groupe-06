﻿using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour {

    Rigidbody _rb;
    GameManager _gm;

    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _rb = col.gameObject.GetComponent<Rigidbody>();
            if (_rb.velocity.x == 0)
            {
                _rb.velocity -= new Vector3(2, 1, 0);
                _gm.Extase -= 5;
            }
        }
    }
}
