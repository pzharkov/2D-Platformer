using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject colliderObject;
    [SerializeField]
    private GameObject triggerObject;
    [SerializeField]
    private float doorDisappearTime;
    [SerializeField]
    private float lockDisappearTime;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private GameObject lockSprite;
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
        triggerObject.SetActive(false);
        
        StartCoroutine(Disappear());
        StartCoroutine(LockDisappear());
    }
    private IEnumerator Disappear()
    {
        float remainingTime = doorDisappearTime;

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            sprite.color = new Color(1f, 1f, 1f, 1f * remainingTime / doorDisappearTime);

            yield return null;
        }
        Destroy(gameObject);
    }
    private IEnumerator LockDisappear()
    {
        // pop-up
        float elapsedTime = 0f;
        Vector2 startingScale = new Vector2(lockSprite.transform.localScale.x, lockSprite.transform.localScale.y);

        while (elapsedTime < lockDisappearTime)
        {
            elapsedTime += Time.deltaTime;
            lockSprite.transform.localScale = startingScale * (1 + elapsedTime / lockDisappearTime);

            yield return null;
        }

        // then fade
        float remainingTime = lockDisappearTime;
        startingScale = new Vector2(lockSprite.transform.localScale.x, lockSprite.transform.localScale.y);

        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            lockSprite.transform.localScale = startingScale * (remainingTime / lockDisappearTime);

            yield return null;
        }

        lockSprite.SetActive(false);
    }

}
