using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy_BASE : MonoBehaviour
{
    [SerializeField] private int life = 1;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float blinkDuration = 0.2f;

    private bool isBlinking = false;    
    private Transform target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        target = Player.GetInstance().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        int waveLevel = EnemySpawner.GetInstace().GetCurrentWaveLevel();

        life = 1 + (waveLevel - 1);
    }

    void Update()
    {
        if (!isBlinking && target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;

            //Flip sprite
            spriteRenderer.flipX = moveDirection.x > 0 ? false : true;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundPlayer.GetInstance().PlayDeathAudio();

        if (!isBlinking && collision.gameObject.CompareTag("Weapon"))
        {
            life--;

            if (life <= 0)
            {
                Die();
            }
            else
            {
                StartCoroutine(BlinkSprite());
            }
        }
    }

    IEnumerator BlinkSprite()
    {
        isBlinking = true;
        int blinkCount = 0;
        while (blinkCount < 3)
        {
            spriteRenderer.color = Color.red; 
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.color = Color.white; 
            yield return new WaitForSeconds(blinkDuration);
            blinkCount++;
        }
        spriteRenderer.color = Color.white; 
        isBlinking = false;

    }

    void Die()
    {        
        GameObject crystalXP = CrystalPools.GetInstance().GetPooledCrystal();
        crystalXP.transform.position = transform.position;
        crystalXP.SetActive(true);
    
        Destroy(gameObject);
    }
}
