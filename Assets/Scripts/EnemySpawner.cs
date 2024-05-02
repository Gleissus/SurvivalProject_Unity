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

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f); // Timer for first spawn

            for (int i = 0; i < enemiesPerWave; i++)
            {
                // SpawnPoint random
                Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

                // Enemy random
                GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

                // instantiate enemy
                Instantiate(randomEnemy, spawnPoint.position, Quaternion.identity);
            }

            yield return new WaitForSeconds(spawnInterval); // Timer for the next spawner
        }
    }
}
