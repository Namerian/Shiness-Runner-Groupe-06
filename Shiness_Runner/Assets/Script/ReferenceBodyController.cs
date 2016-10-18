using UnityEngine;
using System.Collections;

public class ReferenceBodyController : MonoBehaviour {

    float _movespeed;
    
	void Start () {
        StartMove();
	}
	
	void Update () {
        transform.position += new Vector3(_movespeed * Time.deltaTime , 0, 0);
	}

    public void StartMove()
    {
        _movespeed = Global.MOVEMENT_SPEED;
    }

    public void StopMove()
    {
        _movespeed = 0.0f;
    }
}
