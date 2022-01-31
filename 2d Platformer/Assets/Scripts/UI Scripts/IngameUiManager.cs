using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngameUiManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currencyText;
    [SerializeField]
    private TextMeshProUGUI keyText;
    [SerializeField]
    private float countEffectTimer;
    [SerializeField]
    private float standardFontSize;
    [SerializeField]
    private float maxFontSize;
    private IEnumerator keyCoroutine = null;
    private IEnumerator currencyCoroutine;
    [SerializeField]
    private HealthUi healthUi;

    private void Start()
    {
        healthUi = GetComponentInChildren<HealthUi>();
    }
    public void SetKeyCount(int count)
    {
        keyText.SetText("" + count);

        if (keyCoroutine != null)
        {
            StopCoroutine(keyCoroutine);
        }

        keyCoroutine = KeyCountEffect();        
        StartCoroutine(keyCoroutine);        
    }
    public void SetCurrencyAmount(int amount)
    {
        currencyText.SetText("" + amount);

        if (currencyCoroutine != null)
        {
            StopCoroutine(currencyCoroutine);
        }

        currencyCoroutine = CurrencyCountEffect();
        StartCoroutine(currencyCoroutine);
    }
    public void SetHealth(int health)
    {
        healthUi.SetMaxHealth(health);
    }

    private IEnumerator KeyCountEffect()
    {
        float remainingTime = countEffectTimer;
        keyText.fontSize = maxFontSize;

        while (remainingTime > 0)
        {
            keyText.fontSize = standardFontSize + (maxFontSize - standardFontSize) * (remainingTime / countEffectTimer);
            
            remainingTime -= Time.deltaTime;
            yield return null;
        }

        keyText.fontSize = standardFontSize;
    }

    private IEnumerator CurrencyCountEffect()
    {
        float remainingTime = countEffectTimer;
        currencyText.fontSize = maxFontSize;

        while (remainingTime > 0)
        {
            currencyText.fontSize = standardFontSize + (maxFontSize - standardFontSize) * (remainingTime / countEffectTimer);

            remainingTime -= Time.deltaTime;
            yield return null;
        }

        currencyText.fontSize = standardFontSize;
    }
}
