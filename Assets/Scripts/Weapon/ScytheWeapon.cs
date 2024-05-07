using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 1;
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
        transform.position += speed * Time.deltaTime * (Vector3)moveDirection;

        lifeTime -= Time.deltaTime;
                   
        if(lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy_BASE>(out var healthComponent))
        {
            healthComponent.TakeDamage(damage);
        }
    }
}
