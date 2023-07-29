using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    bool isAlreadyCollected = false;

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
}
