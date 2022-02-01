using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{    
    private int currentHealth;
    [SerializeField]
    private float invulnerabilityTime;
    private bool invulnerable;
    private PlayerController playerController = null;
    private GameManager gameManager = null;
    private void Start()
    {
        if (playerController == null)
        {
            playerController = GetComponent<PlayerController>();
        }

        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        currentHealth = gameManager.GetComponent<ProgressManager>().MaxHealth();
        invulnerable = false;
    }
    public void TakeDamage(int amount, Vector2 sourcePosition)
    {
        if (invulnerable)
        {
            return;
        }
        else
        {
            currentHealth -= amount;
            gameManager.GetComponent<ProgressManager>().TakeDamage(amount);

            if (currentHealth <= 0)
            {
                PlayerManager playerManager = GetComponent<PlayerManager>();

                playerManager.PlayerEnteredKillScreen();

                return;
            }
            else
            {
                playerController.DamageKnockBack(sourcePosition);
                StartCoroutine(InvulnerabilityTime());
            }
        }        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyDamage")
        {
            TakeDamage(1, new Vector2(collision.transform.position.x, collision.transform.position.y));
        }
    }

    private IEnumerator InvulnerabilityTime()
    {
        invulnerable = true;
        float remainingTime = invulnerabilityTime;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        invulnerable = false;        
    }
}
