using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffectPool : MonoBehaviour
{
    private static BloodEffectPool instance;

    [SerializeField] GameObject objectPool;
    [SerializeField] int poolCount = 50;

    List<GameObject> pooledObjects = new();
    private int poolIndex;

    public static BloodEffectPool GetInstance() => instance;
    private void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolCount; i++)
        {
            GameObject g = Instantiate(objectPool, Vector2.zero, Quaternion.identity, transform);
            g.SetActive(false);
            pooledObjects.Add(g);
        }
    }

    public GameObject GetPooledBloodEffect()
    {
        poolIndex %= poolCount;

        if (poolIndex == pooledObjects.Count)
        {
            poolIndex = 0;
        }

        return pooledObjects[poolIndex++];
    }
}
