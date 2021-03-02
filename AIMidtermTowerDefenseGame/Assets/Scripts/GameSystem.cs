using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
   public static int money;
   public static int Lives; 
   public static int rounds;
   public int startMoney = 300;
   public int startLives = 30;
  

   public HealthBar health;

   void Start()
   {
        money = startMoney;
        Lives = startLives;
        health.SetMaxHealth(startLives);
        rounds = 0;
   }

    void Update()
    {
        CheckLives();

    }

    void CheckLives()
    {
        health.SetHealth(Lives);
    }
}
