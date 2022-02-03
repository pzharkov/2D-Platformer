using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Progress
{
    public int health;
    public int maxHealth;
    public int currency;
    public int keys;

    public Progress(int _health, int _maxHealth, int _currency, int _keys)
    {
        health = _health;
        maxHealth = _maxHealth;
        currency = _currency;
        keys = _keys;
    }
}
