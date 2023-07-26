using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _burgerPrefab;

    [Space(50)]
    [SerializeField] private float _spawnRate;
    [Range(2,6)]
    [SerializeField] private float _jumpLength;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;


    bool isSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(_spawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Spawn(float time){
        while (isSpawn)
        {

            Vector3 spawnPos  = new Vector3(Random.Range(-100f,100f), 0, Random.Range(-100f, 100f)).normalized*2;
            GameObject newBurger= Instantiate(_burgerPrefab, spawnPos, Quaternion.identity);
            Vector3 jumpPos = transform.position+(spawnPos - transform.position).normalized* (_jumpLength+Random.Range(-1f,1f));
            jumpPos.y += 1;
            

            newBurger.transform.DOJump(jumpPos,_jumpPower,1, _jumpDuration).SetEase(Ease.OutQuad);
            setBurger(newBurger);
            yield return new WaitForSeconds(time);

        }
    }
    private void setBurger(GameObject burger){
        burger.AddComponent<BurgerScript>();
    }
}
