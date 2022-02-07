using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelEvent : MonoBehaviour
{
    private void Update()
    {
        if (FindObjectOfType<CollectibleItem>() == null)
        {
            Debug.Log("End game.");
            FindObjectOfType<GameManager>().GameComplete();
            gameObject.SetActive(false);
        }
    }    
}
