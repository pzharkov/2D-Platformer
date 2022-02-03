using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject regularProjectile;
    [SerializeField]
    private GameObject specialProjectile;
    [SerializeField]
    private Transform spawner;
    [SerializeField]
    private float interval;
    private float elapsedTime = 0f;
    [SerializeField]
    private int frequency;
    private int currentIndex = 0;
    private bool isAlive = true;

    private void Update()
    {
        if (isAlive)
        {
            if (elapsedTime < interval)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime = 0f;
                Shoot();
            }
        }        
    }
    private void Shoot()
    {
        if (currentIndex == frequency - 1)
        {
            Instantiate<GameObject>(specialProjectile, spawner.position, spawner.rotation);
            currentIndex = 0;
        }
        else
        {
            Instantiate<GameObject>(regularProjectile, spawner.position, spawner.rotation);
            currentIndex++;
        }        
    }
    public void IsDead()
    {
        isAlive = false;
    }

}
