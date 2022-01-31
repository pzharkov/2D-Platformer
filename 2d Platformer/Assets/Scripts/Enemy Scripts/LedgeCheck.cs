using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeCheck : MonoBehaviour
{
    EnemyBehaviour enemyBehaviour = null;

    private void Start()
    {
        if (enemyBehaviour == null)
        {
            enemyBehaviour = GetComponentInParent<EnemyBehaviour>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            enemyBehaviour.Flip();
        }
    }
}
