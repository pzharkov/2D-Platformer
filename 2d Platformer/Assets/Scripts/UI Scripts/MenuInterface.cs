using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInterface : MonoBehaviour
{
    public void StartButtonClick()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.Log("StartButtonClick() - No Game Manager found in Scene.");
            return;
        }

        gameManager.LoadNextScene();
    }
    public void QuitButtonClick()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.Log("QuitButtonClick() - No Game Manager found in Scene.");
            return;
        }

        gameManager.QuitGame();
    }
    public void RetryButtonClick()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.Log("RetryButtonClick() - No Game Manager found in Scene.");
            return;
        }

        gameManager.LoadLastPlayedScene();
    }
}
