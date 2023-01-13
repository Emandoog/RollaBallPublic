using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameUIButtons : MonoBehaviour
{

    [SerializeField] Button LevelResetButton1, LevelResetButton2;
    // Start is called before the first frame update
    void Start()
    {
        LevelResetButton1.onClick.AddListener(LevelManager.Instance.RestartLevel);
        LevelResetButton2.onClick.AddListener(LevelManager.Instance.RestartLevel);
       
    }

    
}
