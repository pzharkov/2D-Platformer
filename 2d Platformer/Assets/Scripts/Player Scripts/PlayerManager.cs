using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager = null;
    public void PlayerEnteredKillScreen()
    {
        KillPlayer();
        GameOver();
    }
    public void PlayerReachedExit()
    {
        FindGameManager();
        gameManager.ExitReached();
    }
    public void KillPlayer()
    {
        Debug.Log("Player died.");
        Destroy(gameObject);
    }
    private void GameOver()
    {
        FindGameManager();
        gameManager.GameOver();
    }
    private void FindGameManager()
    {
        if (gameManager != null)
        {
            return;
        }
        gameManager = FindObjectOfType<GameManager>();
    }
}
