using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;
    [SerializeField]
    private GameObject playerObject = null;
    [SerializeField]
    private SceneController sceneController = null;
    [SerializeField]
    private LevelManager activeLevelManager = null;


    void Start()
    {        
        FindSceneController();

        if (sceneController.GetCurrentScene() == 0)
        {
            LoadNextScene();
        }
    }

    public void SpawnPlayer()
    {
        if (playerObject != null)
        {
            Destroy(playerObject);
        }

        playerObject = Instantiate(playerPrefab, activeLevelManager.PlayerSpawnPosition(), Quaternion.identity);
    }

    public void LoadNextScene()
    {
        sceneController.LoadScene(sceneController.GetCurrentScene() + 1);        
    }
    public void LoadPreviousScene()
    {
        sceneController.LoadScene(sceneController.GetCurrentScene() - 1);        
    }
    
    private void FindLevelManager()
    {
        activeLevelManager = FindObjectOfType<LevelManager>();
    }

    private void FindSceneController()
    {
        sceneController = GetComponent<SceneController>();
    }
    public void SceneLoaded()
    {
        FindLevelManager();
    }

}
