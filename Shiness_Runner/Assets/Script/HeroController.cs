using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight;
    public float jumpMin;
    public float jumpForce;
    public float fallSpeed;
    public float gravity;
    public float stunWidth;
    public float slideWidth;
    bool transitioning;

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
    float _jumpMaxReachedX;
    bool _jumpMaxReached;
    bool _jumpCancel;


    void Start()
    {
        _parent = transform.parent.GetComponent<ReferenceBodyController>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _distToGround = _collider.bounds.extents.y;
        _hitPositionStart = 0.0f;
        _slidePositionStart = 0.0f;
        _jumpMaxReachedX = 0.0f;
        _jumpMaxReached = false;
        transitioning = false;
        _jumpCancel = false;
        _transitionTime = 1;
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }


    void Update()
    {
        //gestion du saut
        if(_rb.velocity.y < 0)
        {
            if (_jumpCancel == false)
            {
                if (_jumpMaxReached == false)
                {
                    _jumpMaxReached = true;
                    _jumpMaxReachedX = transform.position.x;
                }

                if (transform.position.x - _jumpMaxReachedX  <= 20)
                {
                    _jumpCancel = true;
                    _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed/100, 0);
                }

            }
            else
            {
                _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed*1.5f, 0);
                _jumpCancel = false;
            }
        }
        else if (((_rb.transform.position.y - _jumpStartLocation) >= jumpHeight && !IsGrounded()) || (_jumpCancel && (_rb.transform.position.y - _jumpStartLocation) >= jumpMin))
        {
            _rb.velocity -= new Vector3(0, fallSpeed, 0); //si on a atteint la hauteur max ou qu'on cancel le saut
        }
        else
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 0); //en temps normal
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
        if (transitioning)
        {
            if (_transitionTimer >= _transitionTime)
            {
                transitioning = false;
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
            _rb.velocity +=  new Vector3(0, jumpForce, 0);
            _jumpStartLocation = transform.position.y;
        }
    }

    public void JumpCancel()
    {
        if (!IsGrounded())
        {
            _jumpCancel = true;
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
        if (!transitioning)
        {
            transitioning = true;
            _transitionTimer = 0;
            _laneTargetPosition = transform.localPosition.z + 3;
        }
    }

    public void LaneDown()
    {
        if (!transitioning)
        {
            transitioning = true;
            _transitionTimer = 0;
            _laneTargetPosition = transform.localPosition.z - 3;
        }
    }
}
