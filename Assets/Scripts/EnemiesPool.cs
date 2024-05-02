using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PoolObject
{
    public GameObject enemies;
    public int amount;
}

public class EnemiesPool : MonoBehaviour
{
    private static EnemiesPool instance;

    [SerializeField] private List<PoolObject> poolObjects = new List<PoolObject>();
   

    public static EnemiesPool GetInstance() => instance;
    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (PoolObject poolObject in poolObjects)
        {
            for (int i = 0; i < poolObject.amount; i++)
            {
                GameObject enemy = Instantiate(poolObject.enemies);
                enemy.SetActive(false);                
            }
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (PoolObject poolObject in poolObjects)
        {
            if (poolObject.amount > 0)
            {
                GameObject enemy = poolObject.enemies;
                poolObject.amount--; // Decrementa a quantidade disponível desse tipo de inimigo na pool
                enemy.SetActive(true); // Ativa o inimigo para uso
                return enemy;
            }
        }

        return null; // Retorna null se não houver inimigos disponíveis em nenhum dos tipos
    }
}
