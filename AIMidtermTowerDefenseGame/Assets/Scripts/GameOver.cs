﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text roundText;
    
    public SceneFader sceneFade;
    public string MenuSceneName = "MainMenu";
    void OnEnable()
    {
        roundText.text = GameSystem.rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFade.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFade.FadeToScene(MenuSceneName);
    }
}
