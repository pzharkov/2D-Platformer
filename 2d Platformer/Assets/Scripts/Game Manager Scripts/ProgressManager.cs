using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    private IngameUiManager ingameUi;
    public Progress currentProgress;
    public Progress savedProgress;
    public void AddCurrency(int amount)
    {
        currentProgress.currency += amount;
        ingameUi.SetCurrencyAmount(currentProgress.currency);
    }    
    public void AddKey()
    {
        currentProgress.keys++;
        ingameUi.SetKeyCount(currentProgress.keys);
    }
    public void RemoveKey()
    {
        currentProgress.keys--;
        ingameUi.SetKeyCount(currentProgress.keys);
    }
    public int KeyCount()
    {
        return currentProgress.keys;
    }
    public int MaxHealth()
    {
        return currentProgress.maxHealth;
    }
    public void SaveProgress()
    {
        savedProgress = currentProgress;
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
        else if (GetComponent<SceneController>().CurrentScene() > 3)
        {
            MaintainProgress();
        }
    }
    private void ResetProgress()
    {
        savedProgress = new Progress(5, 5, 0, 0);
        currentProgress = savedProgress;
        ingameUi.SetMaxHealth(currentProgress.maxHealth);        
    }
    private void MaintainProgress()
    {
        currentProgress = savedProgress;
        ingameUi.SetMaxHealth(currentProgress.maxHealth);
        ingameUi.SetHealth(currentProgress.health);
        ingameUi.SetCurrencyAmount(currentProgress.currency);
        ingameUi.SetKeyCount(currentProgress.keys);
    }    
    public void TakeDamage(int amount)
    {
        currentProgress.health -= amount;
        ingameUi.SetHealth(currentProgress.health);
    }
}
