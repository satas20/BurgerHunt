using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed=1;
    [SerializeField] private float _damage=1;
    [SerializeField] private float _atackCD=1;
    private float timer = 0;

    private Vector3 walkDir;
    private Rigidbody _rigidbody;
    private bool isAtacking =false;

    private GameObject fence;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameObject boss =GameObject.FindGameObjectWithTag("Boss");
      
        walkDir = (boss.transform.position - transform.position).normalized * -1;
        
    }




    // Update is called once per frame
    void Update()
    {
        if (!isAtacking) {
            Move();
        }
        if (isAtacking&&timer<=0) {
            _rigidbody.velocity = Vector3.zero;
            atack(_damage);  
        }
        if (fence == null) { isAtacking = false; }
        else if (!fence.activeInHierarchy) { isAtacking = false; }
        timer -= Time.deltaTime;
    }
    private void Move(){
        _rigidbody.velocity = walkDir * moveSpeed*100 * Time.fixedDeltaTime;
        //transform.Translate(transform.position+walkDir,moveSpeed* Time.fixedDeltaTime);
    }
    private void atack(float damage){
        var fencescript = fence.GetComponentInParent<FenceScript>();

        fencescript.takeDamage(damage);
        timer = _atackCD;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence")){
            isAtacking = true;
            fence = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            isAtacking = false;
        }
    }
    
}

