using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BurgerCollect : MonoBehaviour
{


    public Transform ItemHolderTrasnform;

    public int NumOfItemsHolding = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void AddNewItem(Transform _itemHolder)
    {
        _itemHolder.DOJump(ItemHolderTrasnform.position + new Vector3(0, 0.025f * NumOfItemsHolding, 0), 1.5f, 1, .25f).OnComplete(() =>
      {
          _itemHolder.SetParent(ItemHolderTrasnform, true);
          _itemHolder.localPosition = new Vector3(0, 1f * NumOfItemsHolding, 0);
          _itemHolder.localRotation = Quaternion.identity;
          NumOfItemsHolding++;
      }
            );

        Debug.Log("" + NumOfItemsHolding);
    }      
}
