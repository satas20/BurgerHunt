using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PlayerManager : MonoBehaviour
{
    private CharacterController _controller;
    private Rigidbody _rb;
    private Animator _animator;
    private RepairManager _repairManager;
    public float coin = 0;
    [SerializeField] private Transform collectPoint;
    private BurgerCollect burgercollect;
    private SpawnManager spawnmngr;
    void Start()
    {
        spawnmngr = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpawnManager>();
        burgercollect = GetComponent<BurgerCollect>();
        _repairManager = GetComponent<RepairManager>();
        _rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        updateAniamtion();
        if (Input.GetKey("a")) {
            for (int i = 0; i < collectPoint.childCount; i++) {
                Debug.Log(collectPoint.childCount);

                sellBurger(collectPoint.GetChild(collectPoint.childCount - 1).gameObject);
                burgercollect.NumOfItemsHolding--;
                Destroy(collectPoint.GetChild(collectPoint.childCount - 1).gameObject);
            }

        }
    }
    private void updateAniamtion() {
        _animator.SetFloat("Speed", _rb.velocity.magnitude);
    }

    private void sellBurger(GameObject burger) {


        spawnmngr.spawnGold(1);
        burger.transform.parent = null;
        var boss = GameObject.FindGameObjectWithTag("Boss");
        burger.transform.DOJump(boss.transform.position, 3, 1, 0.5f).SetEase(Ease.OutQuad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FenceRepair")){
            _repairManager.fence = other.transform.parent.gameObject ;
            _repairManager.isRepairing = true;

        }
        if (other.gameObject.CompareTag("BossSell")){
            for (int i = 0; i < collectPoint.childCount; i++)
            {
                Debug.Log(collectPoint.childCount);
                var burger = collectPoint.GetChild(collectPoint.childCount - 1).gameObject;
                sellBurger(collectPoint.GetChild(collectPoint.childCount - 1).gameObject);
                burgercollect.NumOfItemsHolding--;
                Destroy(burger,1f);
            }
        }
        if (other.CompareTag("Coin")){
            Destroy(other.gameObject);
            coin++;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FenceRepair"))
        {
            _repairManager.isRepairing = false;

        }
    }
}
