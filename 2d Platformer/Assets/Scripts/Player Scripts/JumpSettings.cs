using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSettings : MonoBehaviour
{
    private Rigidbody2D rb = null;
    private PlayerController controller = null;
    [SerializeField]
    private float jumpTime = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private float jumpBuffer = 0f;
    [SerializeField]
    private float coyoteeTime = 0f;
    [SerializeField]
    private float fallGravityScale = 0f;
    private bool canJump = false;
    private bool isTryingToJump = false;
    private IEnumerator jumpCoroutine = null;
    private IEnumerator coyoteeTimeCoroutine = null;
    private IEnumerator jumpBufferCoroutine = null;

    private GroundCheck groundCheck = null;
    [SerializeField]
    private int maxNumberOfJumps = 0;
    private int remainingJumps = 0;
    void Start()
    {
        controller = GetComponent<PlayerController>();
        PhysicsSetup();
        GroundDetectionSetup();
    }

    public void TryToJump()
    {
        if (!controller.isJumping)
        {
            if (groundCheck.isGrounded || canJump || remainingJumps > 1)
            {
                Jump();
            }
            else
            {
                // start buffer
                jumpBufferCoroutine = JumpBufferCoroutine();
                StartCoroutine(jumpBufferCoroutine);
            }    
        }
    }

    public void TryToFall()
    {
        if (controller.isJumping)
        {
            Fall();
        }
    }
    public void CoyoteeTimer(bool start)
    {
        // starts or stops coyotee timer
        if (start)
        {
            if (!controller.isJumping)
            {
                Fall();

                coyoteeTimeCoroutine = CoyoteeTimeCoroutine();
                StartCoroutine(coyoteeTimeCoroutine);
            }            
        }
        else
        {
            if (coyoteeTimeCoroutine != null)
            {
                StopCoroutine(coyoteeTimeCoroutine);
            }
            canJump = false;
        }
    }
    public void Landed()
    {
        remainingJumps = maxNumberOfJumps;
        rb.gravityScale = 1;
    }

    private void Jump()
    {
        controller.isJumping = true;

        // stop coyotee time if applicable
        CoyoteeTimer(false);

        // start jump coroutine
        jumpCoroutine = JumpCoroutine();
        StartCoroutine(jumpCoroutine);
    }
    private void Fall()
    {
        if (jumpCoroutine != null)
        {
            StopCoroutine(jumpCoroutine);            
        }
        if (!groundCheck.isGrounded)
        {
            rb.gravityScale = fallGravityScale;
        }

        // zero vertical speed
        controller.movementVector.y = 0f;
        // call sleep-wakeup to stop fixed update from carrying over rb.velocity.y from previous update due to Unity call order.
        rb.Sleep();
        rb.WakeUp();
        controller.isJumping = false;
    }
    IEnumerator JumpCoroutine()
    {        
        float _remainingTime = jumpTime;
        remainingJumps -= 1;

        while (_remainingTime > 0f)
        {
            _remainingTime -= Time.deltaTime;

            controller.movementVector.y = jumpForce * _remainingTime / jumpTime;

            yield return null;
        }

        TryToFall();
    }

    IEnumerator CoyoteeTimeCoroutine()
    {
        canJump = true;
        float _remainingTime = coyoteeTime;
        while (_remainingTime > 0f)
        {
            _remainingTime -= Time.deltaTime;
            yield return null;
        }
        canJump = false;
    }    

    IEnumerator JumpBufferCoroutine()
    {
        float _remainingTime = jumpBuffer;

        while (_remainingTime > 0f)
        {
            _remainingTime -= Time.deltaTime;
            if (groundCheck.isGrounded)
            {
                Jump();
                StopCoroutine(jumpBufferCoroutine);
            }

            yield return null;
        }
    }
    private void PhysicsSetup()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.Log("PhysicsSetup() Error in " + this.name + ": RigidBody2D component on " + gameObject.name + " was not found!");
        }        
    }
    private void GroundDetectionSetup()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (groundCheck == null)
        {
            Debug.Log("GroundDetectionSetup Error in " + this.name + ": GroundCheck component on " + gameObject.name + " children was not found!");
        }
    }
}
