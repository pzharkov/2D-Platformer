using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private int currency;
    private int keyCount;
    [SerializeField]
    private int maxHealth;
    private int currentHealth;
    private IngameUiManager ingameUi;
        
    public void AddCurrency(int amount)
    {
        currency += amount;        
        ingameUi.SetCurrencyAmount(currency);        
    }
    public void AddKey()
    {
        keyCount++;        
        ingameUi.SetKeyCount(keyCount);
    }
    public void RemoveKey()
    {
        keyCount--;
        ingameUi.SetKeyCount(keyCount);
    }
    public int KeyCount()
    {
        return keyCount;
    }
    public int MaxHealth()
    {
        return maxHealth;
    }
    public void NewScene()
    {
        if (ingameUi == null)
        {
            ingameUi = FindObjectOfType<IngameUiManager>();
        }
        if (GetComponent<SceneController>().CurrentScene() == 3)
        {
            ResetProgress();
        }
    }
    private void ResetProgress()
    {
        currency = 0;
        keyCount = 0;
        ingameUi.SetMaxHealth(maxHealth);
        currentHealth = maxHealth;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        ingameUi.SetHealth(currentHealth);
    }
}
