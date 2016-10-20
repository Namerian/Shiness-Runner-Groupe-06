using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight;
    public float jumpMin;
    public float jumpForce;
    public float fallSpeed;
    public float stunWidth;
    public float slideWidth;
    public float diveWidth;
    public bool transitioning { get; private set; }

    //intern variables
    Rigidbody _rb;
    Collider _collider;
    Color _tempColor;
    BoxCollider _bc;
    Animator _anim;
    float _laneTargetPosition;
    float _distToGround;
    float _hitPositionStart;
    float _jumpStartLocation;
    float _transitionTimer;
    float _transitionTime;
    float _jumpMaxReachedX;
    bool _jumpMaxReached;
    bool _jumpCancel;


    void Start()
    {
        _anim = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _bc = GetComponent<BoxCollider>();
        _distToGround = _collider.bounds.extents.y;
        _hitPositionStart = 0.0f;
        //_slidePositionStart = 0.0f;
        _jumpMaxReachedX = 0.0f;
        _jumpMaxReached = false;
        transitioning = false;
        _jumpCancel = false;
        _transitionTime = 0.2f;
        //transform.localEulerAngles = new Vector3(0, 0, 0);
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

                if (transform.position.x - _jumpMaxReachedX  >= diveWidth)
                {
                    _jumpCancel = true;
                }
                _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed/4, 0);

            }
            else
            {
                _rb.velocity = new Vector3(_rb.velocity.x, -fallSpeed, 0);
            }
        }
        else if (((_rb.transform.position.y - _jumpStartLocation) >= jumpHeight && !IsGrounded()) || (_jumpCancel && (_rb.transform.position.y - _jumpStartLocation) >= jumpMin))
        {
            _rb.velocity -= new Vector3(0, fallSpeed, 0); //si on a atteint la hauteur max ou qu'on cancel le saut
        }
        else
        {
            _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, 0); //en temps normal
            if (IsGrounded())
            {
                _jumpCancel = false;
                _jumpMaxReached = false;
            }
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
            //_anim.SetTrigger("RunToJump");
            //_anim.SetTrigger("JumpToRun");
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
        _bc.center = new Vector3(_bc.center.x, _bc.center.y, 0.2f);
        _bc.size = new Vector3(_bc.size.x, _bc.size.y, 0.5f);
        _anim.SetTrigger("RunToSlide");
    }

    public void SlideStop()
    {
        _bc.center = new Vector3(_bc.center.x, _bc.center.y, 0.5f);
        _bc.size = new Vector3(_bc.size.x, _bc.size.y, 1f);
        _anim.SetTrigger("SlideToRun");
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

    public void Ability()
    {
        _anim.SetTrigger("RunToPunch");
        if (GetComponent<HeadButt>())
        {
            GetComponent<HeadButt>().Attack();
        }

        if (GetComponent<LightAttack>())
        {
            GetComponent<LightAttack>().Attack(); ;
        }

        if (GetComponent<WindAttack>())
        {
            GetComponent<WindAttack>().Attack();
        }
        _anim.SetTrigger("PunchToRun");
    }
}
