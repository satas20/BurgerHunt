using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody _rb;
    private Animator _animator;
    private RepairManager _repairManager;
    public float coin=0;
    void Start()
    {
        _repairManager = GetComponent<RepairManager>();
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
    private void Rotate(Vector3 rotation)
    {
        transform.rotation = Quaternion.LookRotation(rotation, Vector3.up);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FenceRepair")){
            _repairManager.fence = other.transform.parent.gameObject ;
            _repairManager.isRepairing = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FenceRepair"))
        {
            _repairManager.isRepairing = false;

        }
    }
}
