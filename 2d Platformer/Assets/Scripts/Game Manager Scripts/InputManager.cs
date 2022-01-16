using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    private TestManager testManager = null;
    private GameManager gameManager = null;
    private bool testingMode;
    private bool menuMode;
    // Start is called before the first frame update
    void Start()
    {
        if (testManager == null)
        {
            testManager = gameObject.GetComponent<TestManager>();
        }
        if (gameManager == null)
        {
            gameManager = gameObject.GetComponent<GameManager>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            testingMode = !testingMode;
        }
        if (testingMode)
        {
            ReadTestingInput();
        }
        else
        {
            if (menuMode)
            {
                ReadMenuInput();
            }
            else
            {
                if (gameManager.PlayerHasControl())
                {
                    ReadPlayerInput();
                }
            }
        }
    }

    private void ReadTestingInput()
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
    private void ReadMenuInput()
    {
    }
    private void ReadPlayerInput()
    {
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
