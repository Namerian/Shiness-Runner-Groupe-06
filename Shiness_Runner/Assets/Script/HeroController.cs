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
    Color _tempColor;
    float _laneTargetPosition;
    float _distToGround;
    float _hitPositionStart;
    float _slidePositionStart;
    float _jumpStartLocation;
    float _transitionTimer;
    float _transitionTime;
    bool _transitioning;


    void Start()
    {
        _parent = transform.parent.GetComponent<ReferenceBodyController>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _distToGround = _collider.bounds.extents.y;
        _hitPositionStart = 0.0f;
        _slidePositionStart = 0.0f;
        _transitioning = false;
        _transitionTime = 1;
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
                _tempColor = GetComponent<Renderer>().material.color;
                GetComponent<Renderer>().material.color = new Color(255, 182, 182);
                _hitPositionStart = transform.position.x;
            }
            else
            {
                if(_hitPositionStart - transform.position.x <= -stunWidth)
                {
                    _rb.velocity = new Vector3(0, 0, 0);
                    _hitPositionStart = 0.0f;
                    GetComponent<Renderer>().material.color = _tempColor;
                }
            }
        }

        /*
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
        }*/

        //gestion transition lane
        if (_transitioning)
        {
            if (_transitionTimer >= _transitionTime)
            {
                _transitioning = false;
            }

            _transitionTimer += Time.deltaTime;
            float _transitionProgress = _transitionTimer / _transitionTime;
            float _mZ = Mathf.SmoothStep(transform.position.z, _laneTargetPosition, _transitionProgress);

            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _mZ);
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

    public void SlideStart()
    {
        transform.localEulerAngles = new Vector3(0, 0, -90);
    }

    public void SlideStop()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }

    public void LaneUp()
    {
        _transitioning = true;
        _transitionTimer = 0;
        _laneTargetPosition = transform.localPosition.z + 3;
    }

    public void LaneDown()
    {
        _transitioning = true;
        _transitionTimer = 0;
        _laneTargetPosition = transform.localPosition.z - 3;
    }
}
