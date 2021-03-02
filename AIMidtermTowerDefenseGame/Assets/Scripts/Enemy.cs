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
    public Color damageFXColor;
    private Renderer FX;
    private Color startColor;
    private bool damageTaken = false;
    private bool slowDamage = false;


    void Start()
    {
        FX = GetComponent<Renderer>();
        startColor = FX.materials[0].color;
        speed = startSpeed;
    }

    void Update()
    {
       DmgFX();
    }
    public void TakeDamage(float amountOfDamage)
    {
        health -= amountOfDamage;
        damageTaken = true;
        StartCoroutine(DelayFX());
        
        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float percent)
    {
        slowDamage = true;
        speed = startSpeed * (1f - percent);

    }

    void Die()
    {
        GameSystem.money += killReward;

        GameObject DEffect = (GameObject)Instantiate(DeathEffect, transform.position, Quaternion.identity);
        Destroy(DEffect, 5f);
        Destroy(gameObject);
    }

    void DmgFX()
    {
        if (damageTaken)
        {
            FX.materials[1].color = damageFXColor;
        }else{
            FX.materials[1].color = startColor;
        }
        
        if (slowDamage)
        {
            FX.materials[0].color = slowFXColor;
        }else{
            FX.materials[0].color =startColor;
        }
    }

    IEnumerator DelayFX()
    {
        yield return new WaitForSeconds(1f);
        slowDamage = false;
        damageTaken = false;
    }

}
