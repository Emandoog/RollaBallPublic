using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotationPowerUI : MonoBehaviour
{

    public static RotationPowerUI Instance { get; private set; }

    private Slider slider;
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }


    public void UpdateRotationPowerUI(float maxValue, float minValue, float value)
    {

        slider.maxValue = maxValue;
        slider.minValue = minValue;
        slider.value = value;




    }

    
}
