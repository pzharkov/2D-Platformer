using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{
    // support class: add to an object to keep it from being destroyed between scenes

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
