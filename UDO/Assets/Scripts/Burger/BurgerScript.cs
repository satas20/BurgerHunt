using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed=1;
    private Vector3 walkDir;
    private Rigidbody _rigidbody;
    private bool isMoving =true;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameObject boss =GameObject.FindGameObjectWithTag("Boss");
      
        walkDir = (boss.transform.position - transform.position).normalized * -1;
    }




    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            Move();}
        
    }
    private void Move(){
        _rigidbody.velocity = walkDir * moveSpeed*100 * Time.fixedDeltaTime;
        //transform.Translate(transform.position+walkDir,moveSpeed* Time.fixedDeltaTime);
    }


}

