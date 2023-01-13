using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointManager : MonoBehaviour
{

    public static event Action OnGameEnd;
    public static PointManager Instance { get; private set; }
    [SerializeField] int playerPoints = 0, maxBanana = 0, banana = 0;

   // [SerializeField]  private GameObject uIPointDisplay;
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
    //banans should have it own script but no time :)
    private void Start()
    {
        PointDisplay.Instance.DisplayPoints(playerPoints);
        BananaDisplay.Instance.DisplayBanans(banana, maxBanana);
    }

    private void OnEnable()
    {
        PointPickUp.OnPointGet += AddBanana;
        PointBonusPickUp.OnPointGet += AddBonusPoint;
        PointPickUp.OnPointSpawn += AddMaxBanana;
    }
    private void OnDisable()
    {
        PointPickUp.OnPointGet -= AddBanana;
        PointBonusPickUp.OnPointGet -= AddBonusPoint;
        PointPickUp.OnPointSpawn -= AddMaxBanana;

    }

    public void ResetPointsEnd()
    {
        banana = 0;
        maxBanana = 0;
        playerPoints = 0;
        PointDisplay.Instance.DisplayPoints(playerPoints);
        BananaDisplay.Instance.DisplayBanans(banana, maxBanana);


    }
    public void ResetPointsStart()
    {

        PointDisplay.Instance.DisplayPoints(playerPoints);
        BananaDisplay.Instance.DisplayBanans(banana, maxBanana);


    }
    private void AddBanana()
    {
        banana += 1;
        playerPoints += 1;
        PointDisplay.Instance.DisplayPoints(playerPoints);
        BananaDisplay.Instance.DisplayBanans(banana, maxBanana);
        if (banana == maxBanana) 
        {
            Debug.Log("All possible bananas gotten :)");
            OnGameEnd?.Invoke();
        }

    }
    private void AddBonusPoint()
    {
        playerPoints += 2;
        PointDisplay.Instance.DisplayPoints(playerPoints);
        //BananaDisplay.Instance.DisplayBanans(banana, maxBanana);


    }
    private void AddMaxBanana()
    {
        maxBanana += 1;


    }

}
