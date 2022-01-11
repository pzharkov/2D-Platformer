using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager = null;
    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = gameObject.GetComponent<GameManager>();
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreatePlayer()
    {
        gameManager.CreatePlayer(new Vector2(0f, 0f));
    }
}
