using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight = 15.0f;
    public float moveSpeed = 0.0f;
    public float gravity = 9.0f;

    //intern variables
    Rigidbody _rb;
    Collider _collider;
    float _yVelocity = 0.0f;
    float _distToGround;
    bool _jumping;


    void Start()
    {
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _distToGround = _collider.bounds.extents.y;
    }


    void Update()
    {
        _rb.velocity = new Vector3(moveSpeed, _rb.velocity.y, 0);
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rb.velocity =  new Vector3(moveSpeed, jumpHeight, 0);
        }
    }


    public void StartMove()
    {
        moveSpeed = 15.0f;
    }


    public void StopMove()
    {
        moveSpeed = 0.0f;
    }
}
