using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float initialLifeTime = 3f;
    private float lifeTime;
    private Vector2 moveDirection;
    

    private void OnEnable()
    {       
        lifeTime = initialLifeTime;
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;

        lifeTime -= Time.deltaTime;
                   
        if(lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
