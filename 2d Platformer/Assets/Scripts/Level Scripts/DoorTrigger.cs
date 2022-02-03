using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{    
    DoorBehaviour doorBehaviour = null;
    
    private void Start()
    {
        doorBehaviour = GetComponentInParent<DoorBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            doorBehaviour.Triggered(collision.GetComponentInParent<PlayerManager>());
        }        
    }
}
