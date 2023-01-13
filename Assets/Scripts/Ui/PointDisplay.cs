using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PointDisplay : MonoBehaviour
{

    public static PointDisplay Instance { get; private set; }

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
    public void DisplayPoints(int currentPoints)
    {

        GetComponent<TextMeshProUGUI>().text = "Points: " + currentPoints;

    }
   

}
