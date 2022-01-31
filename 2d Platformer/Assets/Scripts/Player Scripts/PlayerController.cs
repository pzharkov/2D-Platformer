using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JumpSettings jumpSettings = null;
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float knockBackForce;
    [SerializeField]
    private float controlLossDurationOnDamage;
    [HideInInspector]
    public Vector2 movementVector = new Vector2(0f, 0f);
    [HideInInspector]
    public bool isJumping = false;
    private PlayerManager playerManager = null;

    void Start()
    {
        PhysicsSetup();
        SettingsReference();
        PlayerManagerReference();
    }

    private void FixedUpdate()
    {
        if (playerManager.hasControl)
        {
            if (isJumping)
            {
                rb.velocity = new Vector2(movementVector.x, movementVector.y);
            }
            else
            {
                rb.velocity = new Vector2(movementVector.x, rb.velocity.y);
            }
        }        
    }    

    public void HorizontalMovement(int input)
    {
        movementVector.x = (float)input * speed;
    }
    public void TryingToJump(bool trying)
    {
        if (trying)
        {
            jumpSettings.TryToJump();
        }
        else
        {
            jumpSettings.TryToFall();
        }
    }
    private void PhysicsSetup()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("PhysicsSetup() Error in " + this.name + ": RigidBody2D component on " + gameObject.name + " was not found!");
        }
        else
        {
            movementVector = rb.velocity;
        }        
    }
    private void SettingsReference()
    {
        jumpSettings = GetComponent<JumpSettings>();
        if (jumpSettings == null)
        {
            Debug.Log("SettingsReference() Error in " + this.name + ": JumpSettings component on " + gameObject.name + " was not found!");
        }
    }
    private void PlayerManagerReference()
    {
        playerManager = GetComponent<PlayerManager>();
        if (playerManager == null)
        {
            Debug.Log("PlayerManagerReference() Error in " + this.name + ": PlayerManager component on " + gameObject.name + " was not found!");
        }
    }
    public void DamageKnockBack(Vector2 sourcePosition)
    {
        playerManager.DisableControl(false, controlLossDurationOnDamage);

        Debug.Log("Knockback!");
        float horizontalDirection = 0f;

        if (transform.position.x - sourcePosition.x < 0)
        {
            horizontalDirection = -1f;
        }
        else
        {
            horizontalDirection = 1f;
        }        

        Vector2 forceDirection = new Vector2(horizontalDirection, 0f);
        
        rb.AddForce(forceDirection * knockBackForce, ForceMode2D.Impulse);
    }
}
