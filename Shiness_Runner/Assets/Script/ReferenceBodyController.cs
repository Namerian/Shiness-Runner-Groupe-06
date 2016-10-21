using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReferenceBodyController : MonoBehaviour
{
    private float _movespeed;
    public List<GameObject> Children;

    void Start()
    {
        GetComponent<MeshRenderer>().enabled = false;
        foreach (Transform child in transform)
        {
            if (child.tag == "Player")
            {
                Children.Add(child.gameObject);
            }
        }
    }

    void Update()
    {
        transform.position += new Vector3(_movespeed * Time.deltaTime, 0, 0);
    }

    public void ChangeSpeed(float speed)
    {
        _movespeed = speed;
    }
}
