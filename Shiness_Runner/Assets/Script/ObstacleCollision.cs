using UnityEngine;
using System.Collections;

public class ObstacleCollision : MonoBehaviour {

    Rigidbody _rb;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            _rb = col.gameObject.GetComponent<Rigidbody>();
            _rb.velocity -= new Vector3(2, 0, 0);
        }
    }
}
