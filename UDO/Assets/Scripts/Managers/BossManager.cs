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

    private void FixedUpdate()
    {
        if (slider.value > 00)
        {
            currentTime -= Time.fixedDeltaTime;
            slider.value = (float)currentTime;

        }

        else if (slider.value == 0)
        {
            slider.value = (float)currentTime;
            Debug.Log("Game Over");
            LossPanel.SetActive(true);
            slider.value = 0;
            Time.timeScale = 0;
            Debug.Log(currentTime);
        }

    }
}
