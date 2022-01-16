using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private Vector2 movementVector = new Vector2(0f, 0f);
    private Rigidbody2D rb = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector.y = rb.velocity.y;
    }
        
    private void FixedUpdate()
    {
        rb.velocity = movementVector * 10f;
    }
    void Update()
    {
        
    }

    public void HorizontalMovement(int input)
    {
        movementVector.x = (float)input;
    }
}
