using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight = 5.0f;
    public float jumpForce = 5.0f;
    public float fallSpeed = 1.0f;
    public float moveSpeed = 0.0f;
    public float gravity = 9.0f;
    private float _jumpStartLocation;

    //intern variables
    Rigidbody _rb;
    Collider _collider;
    float _distToGround;


    void Start()
    {
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _distToGround = _collider.bounds.extents.y;
    }


    void Update()
    {
        if(_rb.velocity.y < 0)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed, 0);
        }
        else if ((_rb.transform.position.y - _jumpStartLocation) >= jumpHeight && !IsGrounded())
        {
            _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed, 0);
        }
        else
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 0);
        }
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rb.velocity =  new Vector3(_rb.velocity.x, jumpForce, 0);
            _jumpStartLocation = transform.position.y;
        }
    }
}
