using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded { get; private set; }
    private JumpSettings jumpSettings = null;
    private bool belongsToPlayer = false;

    private void Start()
    {
        // check if belongs to player and try to find jump settings
        jumpSettings = GetComponentInParent<JumpSettings>();
        if (jumpSettings != null)
        {
            belongsToPlayer = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (!isGrounded)
            {                
                isGrounded = true;
            }
            BelongsToPlayerCheck();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isGrounded)
            {                
                isGrounded = false;
            }
            BelongsToPlayerCheck();
        }
    }
    private void BelongsToPlayerCheck()
    {
        // if on player, stop timer if grounded, start if not.
        if (belongsToPlayer)
        {
            jumpSettings.CoyoteeTimer(!isGrounded);

            if (isGrounded)
            {
                jumpSettings.Landed();
            }
        }
    }
}
