using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerManager _playerManager;

    public bool isRepairing;
    public GameObject fence;
    [SerializeField] float repairAmount;
    void Start()
    {
        StartCoroutine(Repair(repairAmount));
        _playerManager = GetComponent<PlayerManager>();
    }

   
    public IEnumerator Repair(float amount)
    {
        while (true)
        {

            if (isRepairing&&fence!=null && fence.GetComponent<FenceScript>().currentHealth<10)
            {
                if (_playerManager.coin > 1){
                    fence.GetComponent<FenceScript>().heal(amount);
                    _playerManager.coin--;

                }
                
            }

            yield return new WaitForSeconds(1);
        }
       
    }
}
