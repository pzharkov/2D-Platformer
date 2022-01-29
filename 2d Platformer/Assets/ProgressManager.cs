using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int currency;
    private int keyCount;
    private IngameUiManager ingameUi;

    private void Start()
    {
        if (ingameUi == null)
        {
            ingameUi = FindObjectOfType<IngameUiManager>();
        }
    }
    public void AddCurrency(int amount)
    {
        currency += amount;
        // update UI
        ingameUi.SetCurrencyAmount(currency);
        Debug.Log("Currency: " + currency);
    }
    public void AddKey()
    {
        keyCount++;
        // update UI
        ingameUi.SetKeyCount(keyCount);
        Debug.Log("Keys: " + keyCount);
    }
}
