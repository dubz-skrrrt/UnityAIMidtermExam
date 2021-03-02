using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
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
        WaveSpawner.wavesComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFade.FadeToScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFade.FadeToScene(MenuSceneName);
    }
}
