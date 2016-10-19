using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReferenceBodyController : MonoBehaviour {

    public float moveSpeed;
    float _movespeed;
    public List<GameObject> Children;
    
	void Start () {
        GetComponent<MeshRenderer>().enabled = false;
        StartMove();
         foreach (Transform child in transform)
         {
             if (child.tag == "Player")
             {
                 Children.Add(child.gameObject);
             }
         }
	}
	
	void Update () {
        transform.position += new Vector3(_movespeed * Time.deltaTime , 0, 0);
	}

    public void StartMove()
    {
        _movespeed = moveSpeed;
    }

    public void StopMove()
    {
        _movespeed = 0.0f;
    }
}
