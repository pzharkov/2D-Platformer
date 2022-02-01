using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject colliderObject;
    [SerializeField]
    private float disappearTime;
    [SerializeField]
    private SpriteRenderer sprite;
    public void Triggered(PlayerManager playerManager)
    {
        if (playerManager.PlayerCanOpenDoor())
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("Not enough keys to open the door!");
        }
    }
    private void OpenDoor()
    {
        colliderObject.SetActive(false);
        StartCoroutine(Disappear());        
    }
    private IEnumerator Disappear()
    {
        float remainingTime = disappearTime;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;            
            sprite.color = new Color(1f, 1f, 1f, 1f * remainingTime / disappearTime);

            yield return null;
        }
        Destroy(gameObject);
    }
}
