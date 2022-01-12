using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab = null;
    [SerializeField]
    private GameObject playerObject = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePlayer(Vector2 position)
    {
        if (playerObject != null)
        {
            Destroy(playerObject);
        }

        playerObject = Instantiate(playerPrefab, position, Quaternion.identity);
    }
}
