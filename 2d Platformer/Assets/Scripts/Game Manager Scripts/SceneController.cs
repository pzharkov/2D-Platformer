using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{    
    private int sceneCount = 0;
    private GameManager gameManager = null;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GetComponent<GameManager>();
        }
        sceneCount = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadScene(int _index)
    {
        if (_index > 0 && _index < sceneCount)
        {
            StartCoroutine(LoadSceneByIndex(_index));
        }
        else
        {
            Debug.Log("Error: scene index called is outside of acceptable range 0 < " + _index + " < " + sceneCount);
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
}
