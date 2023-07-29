using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stacking : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;

    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    private float coinValue = 10f;

    private void addBurger(GameObject burger){
        _cubeList.Add(burger);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            addBurger(other.gameObject);
            AudioManager.Instance.PlaySFX("Burger");
            GameManager.Instance.AddCountCoins(coinValue);
        }
    }
}
