using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded;
    public static bool gameVictory;
    public GameObject gameOverUI;

    public GameObject gameVictoryUI;

    void Start()
    {
        gameEnded = false;
        gameVictory = false;
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

        if (gameVictory)
        {
            return;
        }
        if (WaveSpawner.wavesComplete)
        {
            EndWithVictory();
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

    void EndWithVictory()
    {
        gameVictory = true;
        gameVictoryUI.SetActive(true);
    }
}
