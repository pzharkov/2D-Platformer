using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{    
    private int sceneCount = 0;    
    private int lastPlayedSceneIndex = 2; // set to 2 (Main Menu scene) by default
    private GameManager gameManager = null;
    bool newGame = true;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = GetComponent<GameManager>();            
        }
        sceneCount = SceneManager.sceneCountInBuildSettings;        
    }

    public void LoadScene(int _index)
    {
        if (newGame)
        {
            newGame = false;
            StartCoroutine(LoadSceneByIndex(2));
        }
        else
        {
            if (_index > 0 && _index < sceneCount)
            {
                lastPlayedSceneIndex = CurrentScene();
                StartCoroutine(LoadSceneByIndex(_index));
            }
            else
            {
                Debug.Log("Error: scene index called is outside of acceptable range 0 < " + _index + " < " + sceneCount);
            }
        }        
    }

    IEnumerator LoadSceneByIndex(int _index)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_index);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        
        gameManager.SceneLoaded();
    }

    public int CurrentScene()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public int LastPlayedScene()
    {
        return lastPlayedSceneIndex;
    }
    public void GameComplete()
    {
        newGame = true;
        LoadScene(2);
    }
}
