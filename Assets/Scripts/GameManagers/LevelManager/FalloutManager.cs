using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FalloutManager : MonoBehaviour
{
    public static event Action OnFallout;
    public static FalloutManager Instance { get; private set; }

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

   
    public void BallFallout() 
    {
        OnFallout?.Invoke();

        Debug.Log("Fallout");

        //changecamera
        //show some UI text
        //play sound
        //resetlevel




    }
}
