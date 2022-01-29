using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    [SerializeField]
    private bool isKey;    
    [SerializeField]
    private bool isCurrency;
    [SerializeField]
    private int amount;

    public void Collected()
    {
        ProgressManager progressManager = FindObjectOfType<ProgressManager>();

        if (progressManager == null)
        {
            Debug.Log("CollectTrigger.OnTriggerenter2D: Progress Manager on object was not found!");
            return;
        }

        if (isKey)
        {
            progressManager.AddKey();
        }
        if (isCurrency)
        {
            progressManager.AddCurrency(amount);
        }

        Destroy(gameObject);
    }
}
