using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dependencies : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dependencies;

    public void DestroyDependencies()
    {
        for (int i = 0; i < dependencies.Length; i++)
        {
            Destroy(dependencies[i]);
        }
    }
}
