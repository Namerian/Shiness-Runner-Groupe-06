using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight = 15.0f;
    public float moveSpeed = 0.0f;
    public float gravity = 9.0f;
    private float _moveSpeed = 0.0f;

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
        _rb.velocity = new Vector3(_moveSpeed , _rb.velocity.y, 0);
    }

    bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, _distToGround + 0.1f);
    }

    public void Jump()
    {
        if (IsGrounded())
        {
            _rb.velocity =  new Vector3(_moveSpeed, jumpHeight, 0);
        }
    }


    public void StartMove()
    {
        _moveSpeed = moveSpeed;
    }


    public void StopMove()
    {
        _moveSpeed = 0.0f;

    }
}
