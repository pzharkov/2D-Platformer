using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int currency;
    private int keyNumber;

    public void AddCurrency(int amount)
    {
        currency += amount;
        // update UI
        Debug.Log("Currency: " + currency);
    }
    public void AddKey()
    {
        keyNumber++;
        // update UI
        Debug.Log("Keys: " + keyNumber);
    }
}
