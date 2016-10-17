using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {

    //public variables and properties
    public float jumpHeight;
    public float moveSpeed;
    public bool isJumping
    {
        get
        {
            return isJumping;
        }
        set { }
    }

    //intern variables
    Rigidbody _rb;
    bool _moving;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (_moving == true)
        {
            _rb.MovePosition(new Vector3(moveSpeed, _rb.velocity.y, 0));
        }
    }


    public void Jump()
    {
        _rb.MovePosition(new Vector3(_rb.velocity.x, jumpHeight, 0));
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
