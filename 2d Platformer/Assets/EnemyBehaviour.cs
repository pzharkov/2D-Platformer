using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb = null;
    private bool facingRight = true;
    float direction = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Patrol();
    }
    private void Patrol()
    {
        rb.velocity = new Vector2(direction, rb.velocity.y);
    }

    public void Flip()
    {        
        direction *= -1;

        if (facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        facingRight = !facingRight;
    }
}
