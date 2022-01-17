using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 movementVector = new Vector2(0f, 0f);
    private Rigidbody2D rb = null;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float jumpTime = 1f;
    [SerializeField]
    private float jumpForce = 5f;
    private bool isJumping = false;
    private IEnumerator coroutine = null;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = rb.velocity;
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
        Debug.Log(rb.velocity);
        Debug.Log(isJumping);
    }

    public void HorizontalMovement(int input)
    {
        movementVector.x = (float)input * speed;
    }
    public void TryingToJump(bool trying)
    {
        //check if grounded
        if (trying)
        {
            if (!isJumping)
            {                
                Jump();
            }
        }
        else
        {
            if (isJumping)
            {
                Fall();
            }            
        }
        
        //jump
    }
    
    IEnumerator JumpCoroutine()
    {
        float _remainingTime = jumpTime;
        
        while (_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
            movementVector.y = jumpForce * _remainingTime / jumpTime;

            yield return null;
        }

        isJumping = false;
        movementVector.y = 0f;    
    }
    private void Jump()
    {
        isJumping = true;
        coroutine = JumpCoroutine();
        StartCoroutine(coroutine);
    }
    private void Fall()
    {
        isJumping = false;
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            rb.velocity = new Vector2(movementVector.x, 0f);
        }
    }    
}
