using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 3f;
    [SerializeField] private int enemiesPerWave = 5;


    void Start()
    {
       
        InvokeRepeating("SpawnEnemy", 5f, spawnInterval);
    }

    void SpawnEnemy()
    {
        for(int i = 0; i < enemiesPerWave; i++)
        {            
            // Choose a spawn point
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Random Enemy spawner
            GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

            // Spawner enemy random position
            Instantiate(randomEnemy, spawnPoint.position, Quaternion.identity);
        }                
    }
}
