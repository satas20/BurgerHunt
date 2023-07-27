using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour
{
    [SerializeField] GameObject fence;

    [SerializeField] private float maxHealth;
    private float currentHealth;

    public  bool isBroken=false;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth < 0){
            broke();
        }
    }
    private void broke(){
        fence.SetActive(false);
    }
    public void heal(float amount){
        currentHealth += amount;
    }
    public void repair(){
        currentHealth = maxHealth;
        fence.SetActive(true);
    }
}
