using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChangeManager : MonoBehaviour
{

    public static LevelChangeManager Instance { get; private set; }

    private AsyncOperation asyncLoad;

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

    public void LoadScene(string sceneName)
    {
        

        StartCoroutine(LoadSceneAsync(sceneName));
  
    


    }
    public void RestartScene()
    {

       //SceneManager.LoadScene("SampleScene");
        StartCoroutine(RestartSceneAsync());




    }


    IEnumerator LoadSceneAsync(string sceneName)
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        //asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
          
          
           
            yield return null;

        }


    }
    IEnumerator RestartSceneAsync( )
    {
        asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
        //asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {



            yield return null;

        }
        PointManager.Instance.ResetPointsStart();
        Time.timeScale = 1;

    }


}



