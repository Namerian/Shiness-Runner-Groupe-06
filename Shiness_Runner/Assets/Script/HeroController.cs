using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight = 2.0f;
    public float jumpForce = 8.0f;
    public float fallSpeed = 5.0f;
    public float gravity = 9.0f;
    public float stunWidth = 2.0f;
    public float slideWidth = 5.0f;

    //intern variables
    ReferenceBodyController _parent;
    Rigidbody _rb;
    Collider _collider;
    float _distToGround;
    float _hitPositionStart;
    float _slidePositionStart;
    float _jumpStartLocation;
    Color tempColor;


    void Start()
    {
        _parent = transform.parent.GetComponent<ReferenceBodyController>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _distToGround = _collider.bounds.extents.y;
        _hitPositionStart = 0.0f;
        _slidePositionStart = 0.0f;

        transform.localEulerAngles = new Vector3(0, 0, 0);
    }


    void Update()
    {
        //gestion du saut
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

        //gestion du stun
        if(_rb.velocity.x < 0)
        {
            if(_hitPositionStart == 0.0f)
            {
                tempColor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = new Color(255, 182, 182);
                _hitPositionStart = transform.position.x;
            }
            else
            {
                if(_hitPositionStart - transform.position.x <= -stunWidth)
                {
                    _rb.velocity = new Vector3(0, 0, 0);
                    _hitPositionStart = 0.0f;
                    GetComponent<Renderer>().material.color = tempColor;
                }
            }
        }

        //gestion du slide
        if(transform.localEulerAngles != new Vector3(0, 0, 0))
        {
            if (_slidePositionStart == 0.0f)
            {
                _slidePositionStart = transform.position.x;
            }
            else
            {
                if (transform.position.x - _slidePositionStart  >= slideWidth)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                    _slidePositionStart = 0.0f;
                }
            }
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

    public void Slide()
    {
        transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    public void LineUp()
    {

    }

    public void LineDown()
    {

    }
}
