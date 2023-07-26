using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CollectedManager : MonoBehaviour
{
    public List<GameObject> foodList = new List<GameObject>();
    public GameObject foodPrefab;
    public Transform collectPoint;

    int foodLimit = 10;

    private void OnEnable()
    {
        EventManager.OnFoodCollect += GetFood;
    }
    private void OnDisable()
    {
        EventManager.OnFoodCollect -= GetFood;
    }

    void GetFood()
    {
        if (foodList.Count <= foodLimit)
        {
            GameObject temp = Instantiate(foodPrefab, collectPoint);
            temp.transform.position = new Vector3(collectPoint.position.x, 0.5f+(float)foodList.Count / 20, collectPoint.position.y);
            foodList.Add(temp);
            Debug.Log("getFoodEnable");
            // 37.22s video da 
        }
    }
}
