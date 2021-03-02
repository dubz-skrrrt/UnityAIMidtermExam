using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public string LeveltoLoad ="TowerDefenseLevel";

    public SceneFader sceneFade;
    public void Play()
    {
        sceneFade.FadeToScene(LeveltoLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
