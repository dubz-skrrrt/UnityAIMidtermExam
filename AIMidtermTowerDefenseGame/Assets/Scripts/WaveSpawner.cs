using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{

    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [System.Serializable]
    public class wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float spawnRate;

    }

    public wave[] waves;

    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    public float waveCountDown;
    public int currentWave;
    public Text waveTextTimer;
    public Transform spawnPoint;
    private int enemiesSpawned = 0;

    private float searchCountdown = 1f;
    private SpawnState state = SpawnState.COUNTING;

    void Start()
    {
        waveCountDown = timeBetweenWaves;

    }

    void Update()
    {
        currentWave = nextWave;
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveComplete();
            }
            else
            {
                WaveComplete();
            }
        }

        if (waveCountDown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // Start to spawn the wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountDown -= Time.deltaTime;
            waveCountDown = Mathf.Clamp(waveCountDown, 0f, Mathf.Infinity);
            waveTextTimer.text = "Wave: " + (currentWave+1);
        }
    }

    void WaveComplete()
    {
        Debug.Log("Next Wave");
        state = SpawnState.COUNTING;
        waveCountDown = timeBetweenWaves;

        if (nextWave+1 > waves.Length -1)
        {
            nextWave = 0;
            Debug.Log("waves are complete");
        }else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive ()
    {
        //Debug.Log(waves[currentWave].count);
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null && enemiesSpawned == waves[currentWave].count)
            {
                return false;
            }
        }
        
        return true;
    }
    IEnumerator SpawnWave(wave wave)
    {
        Debug.Log("spawning wave");
        state = SpawnState.SPAWNING;
        GameSystem.rounds++;
        //Enemey spawn
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy (wave.enemy);
            yield return new WaitForSeconds(1f/wave.spawnRate);
            enemiesSpawned++;
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemyType)
    {
        Instantiate(_enemyType, spawnPoint.position, spawnPoint.rotation);
    }
}
