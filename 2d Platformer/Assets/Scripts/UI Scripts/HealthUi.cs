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
    public void SetHealthTo(int max, int current)
    {
        currentHealth = current;
        StartCoroutine(SetHealthCoroutine(max, current));
    }
    public void ReduceHealthTo(int health)
    {        
        for (int i = currentHealth - 1; i >= health; i--)
        {
            healthBlocks[i].Deplete();
        }

        currentHealth = health;
    }

    private IEnumerator SetHealthCoroutine(int max, int current)
    {
        healthBlocks = new HealthBlock[max];
        Vector2 currentPosition = new Vector2(transform.position.x + positionShift, transform.position.y - positionShift);
        for (int i = 0; i < max; i++)
        {
            // isntantiate new block at current position
            GameObject newBlock = Instantiate(healthBlockPrefab, currentPosition, Quaternion.identity);
            newBlock.transform.SetParent(gameObject.transform);
            healthBlocks[i] = newBlock.GetComponent<HealthBlock>();

            // define new position
            currentPosition = new Vector2(currentPosition.x + positionShift, currentPosition.y);
        }
        for (int i = 0; i < current; i++)
        {
            healthBlocks[i].Gain();
            yield return new WaitForSeconds(instantiationDelay);
        }
        for (int i = current; i < max; i++)
        {
            healthBlocks[i].Deplete();
            yield return new WaitForSeconds(instantiationDelay);
        }
    }

}
