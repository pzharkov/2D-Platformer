using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager playerManager = collision.GetComponentInParent<PlayerManager>();

            if (playerManager == null)
            {
                Debug.Log("ExitTrigger.OnTriggerenter2D: Player manager on object " + collision.name + " was not found!");
                return;
            }

            playerManager.PlayerReachedExit();
        }
    }
}
