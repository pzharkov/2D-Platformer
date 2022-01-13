using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private TestManager testManager;
    // Start is called before the first frame update
    void Start()
    {
        if (testManager == null)
        {
            testManager = gameObject.GetComponent<TestManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnPlayer();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadNextScene();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LoadPreviousScene();
        }

    }
    private void SpawnPlayer()
    {        
        testManager.SpawnPlayer();
    }
    private void LoadNextScene()
    {
        testManager.LoadNextScene();
    }
    private void LoadPreviousScene()
    {
        testManager.LoadPreviousScene();
    }
}
