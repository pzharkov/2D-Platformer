using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerObject = null;
    [SerializeField]
    private GameObject player = null;

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
        if (player != null)
        {
            Destroy(player);
        }

        player = Instantiate(playerObject, position, Quaternion.identity);
    }
}
