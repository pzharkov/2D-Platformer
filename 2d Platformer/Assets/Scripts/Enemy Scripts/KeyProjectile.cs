using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyProjectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeSpan;
    Rigidbody2D rb = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        if (transform.rotation.y == 1)
        {
            speed *= -1f;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0f);
    }
    private void Update()
    {
        if (lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
