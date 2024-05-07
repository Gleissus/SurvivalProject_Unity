using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory instance;

    [SerializeField] GameObject[] weakEnemy;
    [SerializeField] GameObject strongEnemy;

    public static EnemyFactory GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject CreateWeakEnemy(Transform position, Quaternion rotation)
    {
        //remplacer par object pool
        GameObject randomEnemy = weakEnemy[Random.Range(0, weakEnemy.Length)];
        return Instantiate(randomEnemy, position.position, rotation);
    }

    public GameObject CreateStrongEnemy(Transform position, Quaternion rotation) 
    {

        return Instantiate(strongEnemy, position.position, rotation);
    }

}
