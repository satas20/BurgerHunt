using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody _rb;
    private Animator _animator;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        updateAniamtion();
    }
    private void updateAniamtion(){
        _animator.SetFloat("Speed",_rb.velocity.magnitude);
    }

}
