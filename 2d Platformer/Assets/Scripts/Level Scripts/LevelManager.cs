using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerSpawnObject = null;

    void Start()
    {
    }

    public Vector3 PlayerSpawnPosition()
    {
        return playerSpawnObject.transform.position;
    }

}
