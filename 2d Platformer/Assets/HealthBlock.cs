using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBlock : MonoBehaviour
{
    [SerializeField]
    private Sprite fullBlock;
    [SerializeField]
    private Sprite emptyBlock;
    private Image imageComponent;
    [SerializeField]
    private RectTransform rt;

    [SerializeField]
    private float standardSize;
    [SerializeField]
    private float maxSize;
    [SerializeField]
    private float effectDuration;

    private void Start()
    {
        imageComponent = GetComponentInChildren<Image>();
    }
    public void Gain()
    {        
        imageComponent.sprite = fullBlock;
        StartCoroutine(PlayAnimation());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Deplete();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Gain();
        }
    }
    public void Deplete()
    {
        imageComponent.sprite = emptyBlock;
        StartCoroutine(PlayAnimation());
    }
    private IEnumerator PlayAnimation()
    {
        float remainingTime = effectDuration;
        
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            float newSize = standardSize + (maxSize - standardSize) * remainingTime / effectDuration;
            rt.sizeDelta = new Vector2(newSize, newSize);
            
            yield return null;
        }

        rt.sizeDelta = new Vector2(standardSize, standardSize);        
    }
}
