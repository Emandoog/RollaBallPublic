using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BananaDisplay : MonoBehaviour
{
    public static BananaDisplay Instance { get; private set; }

    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
   
    public void DisplayBanans(int currentBanans, int maxBanans)
    {

        GetComponent<TextMeshProUGUI>().text = "Bananas: " + currentBanans + "/" + maxBanans;

    }
}
