using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private GameManager gameManager = null;
    public bool hasControl = true;
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
    public bool PlayerCanOpenDoor()
    {
        FindGameManager();
        int keyCount = gameManager.GetComponent<ProgressManager>().KeyCount();

        if (keyCount > 0)
        {
            gameManager.GetComponent<ProgressManager>().RemoveKey();
            return true;
        }
        else
        {
            Debug.Log("Open door");
            return false;
        }
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
    public void DisableControl(bool permanent, float duration)
    {
        if (permanent)
        {
            hasControl = false;
        }
        else
        {
            StartCoroutine(LoseControlTimer(duration));
        }
    }
    private IEnumerator LoseControlTimer(float duration)
    {
        hasControl = false;
        float remainingTime = duration;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        hasControl = true;
    }
}
