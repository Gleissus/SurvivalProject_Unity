using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies; 
    [SerializeField] private float spawnInterval = 3f; 
    [SerializeField] private float spawnAreaWidth = 20f; 
    [SerializeField] private float spawnAreaHeight = 20f; 

    void Start()
    {
       
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Position Area
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnAreaWidth / 2f, spawnAreaWidth / 2f),
                                            Random.Range(-spawnAreaHeight / 2f, spawnAreaHeight / 2f));

        // Random Enemy spawner
        GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

        // Spawner enemy random position
        Instantiate(randomEnemy, spawnPosition, Quaternion.identity);
    }
}
