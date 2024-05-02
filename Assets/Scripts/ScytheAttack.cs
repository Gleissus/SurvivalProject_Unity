using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2 screenBounds;
    private Vector2 moveDirection;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        moveDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
                   
        if(transform.position.x > screenBounds.x)
        {
            Destroy(gameObject);
        }
    }
}
