using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    Rigidbody2D rb = null;
    private bool facingRight = true;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float explosionTime;

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
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Flip()
    {        
        speed *= -1;

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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bomb")
        {
            Destroy(collision.transform.parent.gameObject);
            if (GetComponent<ProjectileSpawner>() != null)
            {
                GetComponent<ProjectileSpawner>().IsDead();
            }
            StartCoroutine(Explode());
        }
    }
    private IEnumerator Explode()
    {
        float remainingTime = explosionTime;
        
        SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.color = Color.white;

        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;            

            float progress = remainingTime / explosionTime;
            spriteRenderer.color = new Color(1f, 1f, 1f, progress);

            yield return null;
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
