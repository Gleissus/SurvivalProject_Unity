using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BASE : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    
    private Transform target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        target = Player.GetInstance().transform;

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;

            if(moveDirection.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Die();
    }

    void Die()
    {
        SoundPlayer.GetInstance().PlayDeathAudio();
        GameObject crystalXP = CrystalPools.GetInstance().GetPooledCrystal();
        crystalXP.transform.position = transform.position;
        crystalXP.SetActive(true);
    
        Destroy(gameObject);
    }
}
