using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMTracker : MonoBehaviour
{
    // support class to track if there is GameManager present in the scene and create one if not
    // this is to allow testing scenes independently as the final build will have GameManager instantiated in the pre-load scene and persist when changing scenes

    [SerializeField]
    private GameObject gameManagerPrefab = null;

    void Start()
    {
        GameManager _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
        {
            GameObject _gameManagerObject = Instantiate(gameManagerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            _gameManager = _gameManagerObject.GetComponent<GameManager>();
            
            _gameManager.SceneLoaded();            
        }
    }
}
