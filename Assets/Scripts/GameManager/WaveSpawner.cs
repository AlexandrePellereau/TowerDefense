using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    
    public Wave[] waves;
    
    public Transform spawnPoint;
    
    public TextMeshProUGUI waveCountdownText;
    
    public GameManager gameManager;
    
    public float timeBetweenWaves = 5f;
    
    private float countdown = 2f;
    private int waveIndex = 0;
    
    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        
        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        
        countdown -= Time.deltaTime;
        
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }
    
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;
        
        Wave wave = waves[waveIndex];
        
        EnemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemyPrefab);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waveIndex++;
    }
    
    void SpawnEnemy(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
