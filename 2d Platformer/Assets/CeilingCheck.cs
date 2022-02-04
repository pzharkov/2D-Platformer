using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCheck : MonoBehaviour
{
    JumpSettings jumpSettings = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ceiling")
        {
            if (jumpSettings == null)
            {
                jumpSettings = GetComponentInParent<JumpSettings>();
            }
            
            jumpSettings.TryToFall();
        }
    }

    
    
}
