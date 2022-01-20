using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private JumpSettings jumpSettings = null;
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 2f;
    [HideInInspector]
    public Vector2 movementVector = new Vector2(0f, 0f);
    [HideInInspector]
    public bool isJumping = false;

    void Start()
    {
        PhysicsSetup();
        SettingsReference();        
    }

    private void FixedUpdate()
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
    void Update()
    {
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
}
