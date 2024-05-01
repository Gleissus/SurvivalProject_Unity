using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Merman : MonoBehaviour
{
    [SerializeField] private float speed = 2f; 
    private Transform target; 

    void Start()
    {        
        target = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        if (target != null)
        {            
            Vector3 moveDirection = (target.position - transform.position).normalized;           
            transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundPlayer.GetInstance().PlayDeathAudio();
        Destroy(gameObject);
    }

    void Die()
    {

    }
}
