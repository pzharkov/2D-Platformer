using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    private GameObject playerPrefab = null;    
    public GameObject PlayerObject { get; private set; }
    [SerializeField]
    private SceneController sceneController = null;
    [SerializeField]
    private LevelManager activeLevelManager = null;    
    public bool PlayerHasControl { get; private set; }

    void Start()
    {
        LoadResources();
        FindSceneController();

        // temp for testing
        PlayerHasControl = true;
    }

    public void SpawnPlayer()
    {
        if (PlayerObject != null)
        {
            Destroy(PlayerObject);
        }

        PlayerObject = Instantiate(playerPrefab, activeLevelManager.PlayerSpawnPosition(), Quaternion.identity);
        GetComponent<InputManager>().NewPlayerReference();
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
