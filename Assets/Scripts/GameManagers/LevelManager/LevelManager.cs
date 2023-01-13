using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }


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
    private void OnEnable()
    {
        PointManager.OnGameEnd += GameEnd;
    }
    private void OnDisable()
    {
        PointManager.OnGameEnd -= GameEnd;
    }



    public void RestartLevel()
    {
        
        PointManager.Instance.ResetPointsEnd();
        UIManager.Instance.DeactivateFalloutUI();
        UIManager.Instance.DeactivateGameEndUI();
        LevelChangeManager.Instance.RestartScene();
       





    }
    public void GameEnd()
    {
        Time.timeScale = 0;


    }
    public void OpenExit() 
    { 
    //open exit  to next level
    
    }
    

}

