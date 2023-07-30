using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
 

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _burgerPrefab;
    [SerializeField] private GameObject _coinPrefab;

    [Space(50)]
    [SerializeField] private float _spawnRate;
    [Range(2,6)]
    [SerializeField] private float _jumpLength;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _jumpDuration;
    private GameObject player;

    bool isSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Spawn(_spawnRate));
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }
    private void Rotate()
    {
        var dir = player.transform.position-transform.position;
        transform.rotation = Quaternion.LookRotation(dir, Vector3.up);
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
     public void spawnGold(int amount) {
        for(int i = 0; i < amount; i++){
            Debug.Log("spawned");
            Quaternion target = Quaternion.Euler(0, Random.Range(-180f,180f),0);
            Vector3 spawnPos = new Vector3(Random.Range(-100f, 100f), 0, Random.Range(-100f, 100f)).normalized * 2;
            GameObject newCoin = Instantiate(_coinPrefab, spawnPos, target);
            Vector3 jumpPos = transform.position + (spawnPos - transform.position).normalized * (6+Random.Range(-2f, 4f));
            jumpPos.y += 1;


            newCoin.transform.DOJump(jumpPos, 7, 1, 0.7f).SetEase(Ease.OutQuad);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food")){
            Destroy(other.gameObject);
        }
    }
}
