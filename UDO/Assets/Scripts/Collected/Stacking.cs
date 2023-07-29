using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;

    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    private float coinValue = 10f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)){
            Debug.Log("A");
            removeburger();
        }
    }
    private void addBurger(GameObject burger){
        if (_cubeList.Contains(burger))
            return;
        _cubeList.Add(burger);
        Destroy(burger.gameObject.GetComponent<BurgerScript>());
        Destroy(burger.gameObject.GetComponent<Rigidbody>());

        burger.gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        if (_cubeList.Count == 1)
        {
            



            _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
            _currentCubePos = new Vector3(burger.transform.position.x, _firstCubePos.y, burger.transform.position.z);
            burger.gameObject.transform.position = _currentCubePos;
            _currentCubePos = new Vector3(burger.transform.position.x, transform.position.y + 0.3f, burger.transform.position.z);
            
            burger.gameObject.GetComponent<Cube>().UpdateCubePosition(transform, true);
        
        }
        else if (_cubeList.Count > 1)
        {
            burger.gameObject.transform.position = _currentCubePos;
            _currentCubePos = new Vector3(burger.transform.position.x, burger.gameObject.transform.position.y + 0.3f, burger.transform.position.z);
            burger.gameObject.GetComponent<Cube>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
            _cubeListIndexCounter++;
        }
    }
    private void removeburger ( ){

        var burger = _cubeList[_cubeList.Count-1];
        _cubeList.RemoveAt(_cubeListIndexCounter);
        if(_cubeListIndexCounter-->0)
            _cubeListIndexCounter--;
        Destroy(burger.gameObject.GetComponent<Cube>());
        //remove burger here 


        var boss = GameObject.FindGameObjectWithTag("Boss");
        boss.GetComponent<SpawnManager>().spawnGold(3);
        burger.transform.DOJump(boss.transform.position, 4, 1, 0.5f).SetEase(Ease.OutQuad) ;
        //Destroy(burger);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            addBurger(other.gameObject);
            AudioManager.Instance.PlaySFX("Burger");
            GameManager.Instance.AddCountCoins(coinValue);
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            addBurger(collision.gameObject);
            AudioManager.Instance.PlaySFX("Burger");
            GameManager.Instance.AddCountCoins(coinValue);
        }
    }
}
