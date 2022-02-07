using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;
    public GameObject playerObject;
    public GameObject playerDummy;
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
        if (playerObject != null)
        {
            playerObject.GetComponent<PlayerManager>().KillPlayer();
        }

        playerObject = Instantiate(playerPrefab, activeLevelManager.PlayerSpawnPosition(), Quaternion.identity);
        GetComponent<InputManager>().NewPlayerReference(playerObject.GetComponent<PlayerController>());
    }
    public void GameOver()
    {
        sceneController.LoadScene(1);
    }

    public void GameComplete()
    {
        GameObject _dummy = Instantiate(playerDummy, playerObject.transform.position, Quaternion.identity);
        playerObject.SetActive(false);
        StartCoroutine(FinishGame());

    }
    private IEnumerator FinishGame()
    {        
        yield return new WaitForSeconds(3f);
        // main menu
        sceneController.GameComplete();
    }
    public void ExitReached()
    {
        GetComponent<ProgressManager>().SaveProgress();
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        sceneController.LoadScene(sceneController.CurrentScene() + 1);        
    }
    public void LoadPreviousScene()
    {
        sceneController.LoadScene(sceneController.CurrentScene() - 1);        
    }
    public void LoadLastPlayedScene()
    {
        sceneController.LoadScene(sceneController.LastPlayedScene());
    }
    private void FindLevelManager()
    {
        activeLevelManager = FindObjectOfType<LevelManager>();
    }
    private void FindSceneController()
    {
        if (sceneController == null)
        {
            sceneController = GetComponent<SceneController>();
        }        

        // check if in Zero (pre-load scene) and load next scene if so
        if (sceneController.CurrentScene() == 0)
        {
            LoadNextScene();
        }
    }
    public void SceneLoaded()
    {
        FindLevelManager();
        FindSceneController();
        GetComponent<ProgressManager>().NewScene();
        
        if (sceneController.CurrentScene() > 2)
        {
            SpawnPlayer();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void LoadResources()
    {
        playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
        playerDummy = Resources.Load<GameObject>("Prefabs/PlayerDummy");
    }
}
