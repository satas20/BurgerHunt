using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class FenceScript : MonoBehaviour
{
    [SerializeField] GameObject fence;

    [SerializeField] private float maxHealth;
     public float currentHealth;
     [SerializeField] private Slider slider;
    [SerializeField] GameObject repairArea;

    [SerializeField] private GameObject bar;
    [SerializeField] private  Image fill;
    [SerializeField] private Gradient gradient;


    public  bool isBroken=false;
    void Start()
    {
        currentHealth = maxHealth;
        SetMaxHealth();
    }
    private void Update()
    {
        if(currentHealth >= maxHealth){
            repairArea.SetActive(false);
        }
            if (currentHealth >= maxHealth || currentHealth < 0) { bar.SetActive(false);
            
        }
        else { bar.SetActive(true);
            repairArea.SetActive(true);
        }
    }

    public void takeDamage(float damage){
        transform.DOShakeRotation(0.3f,10,15);
        currentHealth -= damage;
        if (currentHealth < 0){
            broke();
        }
        SetHealth();
    }
    private void broke(){
        fence.SetActive(false);
    }
    public void heal(float amount){
        AudioManager.Instance.PlaySFX("Repair");
        if (currentHealth < maxHealth) { currentHealth += amount; }
        SetHealth();
        if (currentHealth > 0 ){
            fence.SetActive(true);
        }
    }
    public void repair(){
        currentHealth = maxHealth;
        
        fence.SetActive(true);
    }

    private void SetMaxHealth() {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }
    private void SetHealth( )
    {
        AudioManager.Instance.PlaySFX("Repair");
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
