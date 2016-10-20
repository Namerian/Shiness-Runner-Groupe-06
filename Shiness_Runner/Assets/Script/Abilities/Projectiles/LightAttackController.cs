﻿using UnityEngine;
using System.Collections;

public class LightAttackController : MonoBehaviour {

    public float speed;
    public float range;
    float _startPosition;

    void Start()
    {
        _startPosition = transform.position.x;
    }

    void Update()
    {
        transform.position += new Vector3(speed / 10, 0);
        if (transform.position.x - _startPosition >= range)
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Contains("Enemy_Bat"))
        {
            //add score enemy
            Destroy(col.gameObject);
        }
        Destroy(gameObject);
    }
}