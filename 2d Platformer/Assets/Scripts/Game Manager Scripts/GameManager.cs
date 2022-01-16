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
        LoadResources();
        FindSceneController();
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
        sceneController.LoadScene(sceneController.CurrentScene() + 1);        
    }
    public void LoadPreviousScene()
    {
        sceneController.LoadScene(sceneController.CurrentScene() - 1);        
    }
    
    private void FindLevelManager()
    {
        activeLevelManager = FindObjectOfType<LevelManager>();
    }

    private void FindSceneController()
    {
        sceneController = GetComponent<SceneController>();

        // check if in Zero (pre-load scene) and load next scene if so
        if (sceneController.CurrentScene() == 0)
        {
            LoadNextScene();
        }

    }
    public void SceneLoaded()
    {
        FindLevelManager();
    }

    private void LoadResources()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
    }

}
