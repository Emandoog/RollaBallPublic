using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIManager : MonoBehaviour
{


    public static event Action OnFallout;
    public static UIManager Instance { get; private set; }

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
    [SerializeField] GameObject falloutText;
    [SerializeField] GameObject gameEndDiv;
    // Start is called before the first frame update

    private void OnEnable()
    {
        FalloutManager.OnFallout += ActivateFalloutUI;
        PointManager.OnGameEnd += ActivateGameEndUI;
    }
    private void OnDisable()
    {
        FalloutManager.OnFallout -= ActivateFalloutUI;
        PointManager.OnGameEnd -= ActivateGameEndUI;
    }
    
    public void ActivateInGameMenuUI(bool activate = true)
    {


    }
   
    private void  ActivateFalloutUI() 
    {
        falloutText.SetActive(true);
    
    }
    public void DeactivateFalloutUI()
    {
        falloutText.SetActive(false);

    }
    public void ActivateGameEndUI() 
    {
        gameEndDiv.SetActive(true);


    }
    public void DeactivateGameEndUI()
    {

        gameEndDiv.SetActive(false);
    }
}
