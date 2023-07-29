using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    bool isAlreadyCollected = false;
    private Animator _animator;

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isAlreadyCollected)
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            BurgerCollect myCollect;
            if (other.TryGetComponent(out myCollect))
            {
               
                myCollect.AddNewItem(this.transform);
                isAlreadyCollected = true;
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (isAlreadyCollected)
        {
            return;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("is›dle", true);
            GetComponent<CapsuleCollider>().isTrigger = true;
            Destroy(GetComponent<Rigidbody>());
            
            //GetComponent<Rigidbody>().freezeRotation=true;
            //GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(GetComponent<BurgerScript>());
            BurgerCollect myCollect;
            if (other.gameObject.TryGetComponent(out myCollect))
            {   
                myCollect.AddNewItem(this.transform);
                isAlreadyCollected = true;
            }
        }
    }
}
