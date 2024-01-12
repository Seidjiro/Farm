using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _ch_animator;
    [SerializeField] private FixedJoystick _joystick;
    
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _ch_animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(-_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, -_joystick.Vertical * _moveSpeed);
    
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            //transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            _ch_animator.SetBool("Move", true);
        }
        else
        {
            _ch_animator.SetBool("Move", false);
        }
    }
}
