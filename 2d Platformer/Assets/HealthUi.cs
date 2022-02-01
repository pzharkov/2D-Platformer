using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUi : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBlockPrefab;
    [SerializeField]
    private HealthBlock[] healthBlocks;
    [SerializeField]
    private float instantiationDelay;
    private float positionShift;
    private int currentHealth = 0;

    private void Start()
    {
        positionShift = healthBlockPrefab.GetComponent<HealthBlock>().standardSize * 1.5f;
    }
    public void SetMaxHealth(int health)
    {
        currentHealth = health;
        StartCoroutine(SetMaxHealthCoroutine(health));
    }

    private IEnumerator SetMaxHealthCoroutine(int health)
    {
        healthBlocks = new HealthBlock[health];
        Vector2 currentPosition = new Vector2(transform.position.x + positionShift, transform.position.y - positionShift);
        for (int i = 0; i < health; i++)
        {
            // isntantiate new block at current position
            GameObject newBlock = Instantiate(healthBlockPrefab, currentPosition, Quaternion.identity);
            newBlock.transform.SetParent(gameObject.transform);
            healthBlocks[i] = newBlock.GetComponent<HealthBlock>();
            healthBlocks[i].Gain();

            // define new position
            currentPosition = new Vector2(currentPosition.x + positionShift, currentPosition.y);            

            yield return new WaitForSeconds(instantiationDelay);
        }
    }

}
