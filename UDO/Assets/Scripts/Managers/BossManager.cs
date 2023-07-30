using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    public Slider slider;
    public float countdownTime;
    public float currentTime;
    [SerializeField] GameObject LossPanel;
    [SerializeField] GameObject WinPanel;

    private void Start()
    {
        currentTime = countdownTime;
        slider.maxValue = countdownTime;
        slider.value = currentTime;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            slider.value = currentTime;
        }

        if (currentTime < 0)
        {
            Debug.Log("Game Over");
            LossPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
