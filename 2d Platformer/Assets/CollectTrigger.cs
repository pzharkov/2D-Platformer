using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ProgressManager progressManager = FindObjectOfType<ProgressManager>();

            if (progressManager == null)
            {
                Debug.Log("CollectTrigger.OnTriggerenter2D: Progress Manager on object was not found!");
                return;
            }

            progressManager.AddCurrency(1);

            Destroy(transform.parent.gameObject);
        }
    }
}
