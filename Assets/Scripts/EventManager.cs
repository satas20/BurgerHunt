using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnFoodCollect;

    bool isCollecting;

    private void Start()
    {
        StartCoroutine(CollectEnum());
    }
    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting == true)
            {
                OnFoodCollect();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
        }
    }
}
