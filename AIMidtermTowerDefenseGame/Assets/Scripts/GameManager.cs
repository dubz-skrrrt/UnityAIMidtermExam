using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public GameObject gameOverUI;

    void Start()
    {
        gameEnded = false;
    }
    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (GameSystem.Lives <=0)
        {
            EndGame();
        }
         //testing code
        // if (Input.GetKeyDown("e"))
        // {
        //     EndGame();
        // }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
