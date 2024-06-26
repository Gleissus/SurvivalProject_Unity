using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner instance;


    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float initialSpawnInterval = 10f;
    [SerializeField] private int initialEnemiesPerWave = 20;
    [SerializeField] private float waveInterval = 2f;
    [SerializeField] private float increasePercentage = 0.1f;

    private float currentSpawnInterval;
    private int currentEnemiesPerWave;
    private int currentWaveLevel = 1;

    public static EnemySpawner GetInstace() => instance;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        currentEnemiesPerWave = initialEnemiesPerWave;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval); // Timer between waves

            for (int i = 0; i < currentEnemiesPerWave; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    // SpawnPoint random
                    Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    Quaternion rotation = Quaternion.identity;

                    //Chance for Spawn
                    int randomNumber = Random.Range(0, 100);

                    if(randomNumber < 90)
                    {
                        EnemyFactory.GetInstance().CreateWeakEnemy(spawnPoint, rotation);
                    }
                    else
                    {
                        EnemyFactory.GetInstance().CreateStrongEnemy(spawnPoint, rotation);
                    }                                        
                }                
                yield return new WaitForSeconds(5);
            }

            currentEnemiesPerWave = Mathf.CeilToInt(currentEnemiesPerWave * (1 + increasePercentage));
            currentSpawnInterval *= (1 - increasePercentage);
            currentWaveLevel++;
            UIController.instance.PrintWaveLevel(currentWaveLevel);

            yield return new WaitForSeconds(waveInterval); // Timer for the next wave
        }
    }

    public int GetCurrentWaveLevel()
    {
        return currentWaveLevel;
    }
}
