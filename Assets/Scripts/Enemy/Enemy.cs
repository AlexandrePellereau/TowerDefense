using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10;
    [HideInInspector]
    public float speed = 10f;
    
    public float startHealth = 100;
    private float health;
    
    public int worth = 50;
    
    public GameObject deathEffect;
    
    [Header("Unity Stuff")]
    public Image healthBar;
    
    private bool isDead = false;
    
    public void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }
    
    public void TakeDamage(float amount)
    {
        health -= amount;
        
        healthBar.fillAmount = health / startHealth;
        
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    
    void Die()
    {
        isDead = true;
        
        PlayerStats.Money += worth;
        
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        
        WaveSpawner.EnemiesAlive--;
        
        if (WaveSpawner.EnemiesAlive <= 0)
        {
            CameraShake.Instance.ShakeCamera();
        }
        
        Destroy(gameObject);
    }

    
}
