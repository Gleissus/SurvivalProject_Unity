using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2 screenBounds;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));    
    }

    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
                   
        if(transform.position.x > screenBounds.x)
        {
            Destroy(gameObject);
        }
    }
}
