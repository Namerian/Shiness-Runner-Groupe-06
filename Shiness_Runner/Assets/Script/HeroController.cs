using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight;
    public float moveSpeed;
    public bool IsJumping
    {
        get
        {
            return IsJumping;
        }

        private set { }
    }

    //intern variables
    Rigidbody _rb;
    bool _moving;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        IsJumping = false;
        _moving = false;
    }


    void Update()
    {
        if (_moving == true)
        {
            _rb.velocity = new Vector3(moveSpeed, _rb.velocity.y, 0);
        }
    }


    public void Jump()
    {
        if (IsJumping == false)
        {
            IsJumping = true;
            _rb.velocity = new Vector3(_rb.velocity.x, jumpHeight, 0);
        }
    }


    public void StartMove()
    {
        _moving = true;
    }


    public void StopMove()
    {
        _moving = false;
    }
}
