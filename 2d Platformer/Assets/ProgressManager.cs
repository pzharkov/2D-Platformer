using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int currency;

    public void AddCurrency(int amount)
    {
        currency += amount;
        // update UI
        Debug.Log("Currency: " + currency);
    }
}
