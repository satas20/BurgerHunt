using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private float coinValue;
    [SerializeField] TextMeshProUGUI scorText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void AddCountCoins(float amount)
    {
        coinValue += amount;
        scorText.text = coinValue.ToString();
    }

}
