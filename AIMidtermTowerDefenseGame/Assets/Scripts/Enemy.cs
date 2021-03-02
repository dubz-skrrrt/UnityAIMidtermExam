using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    
    public float health;
    public int killReward = 10;

    public GameObject DeathEffect;
    public Color slowFXColor;
    private Renderer slowFX;
    private Color startColor;



    void Start()
    {
        slowFX = GetComponent<Renderer>();
        startColor = slowFX.materials[0].color;
        speed = startSpeed;
    }

    void Update()
    {
        if (speed < startSpeed)
        {
            slowFX.materials[0].color = slowFXColor;
        }else{
            slowFX.materials[0].color =startColor;
        }
    }
    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);

    }

    void Die()
    {
        GameSystem.money += killReward;

        GameObject DEffect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(DEffect, 5f);
        Destroy(gameObject);
    }

}
