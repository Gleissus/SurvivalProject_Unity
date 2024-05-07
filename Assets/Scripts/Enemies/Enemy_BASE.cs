using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Enemy_BASE : MonoBehaviour
{
    
    [SerializeField] private int maxHealth;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private float blinkDuration = 0.2f;

    private int curentHealth;
    private bool isBlinking = false;    
    private Transform target;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        target = Player.GetInstance().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        int waveLevel = EnemySpawner.GetInstace().GetCurrentWaveLevel();

        curentHealth = maxHealth + (waveLevel - 1);
    }

    void Update()
    {
        if (!isBlinking && target != null)
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;
            transform.position += speed * Time.deltaTime * moveDirection  ;

            //Flip sprite
            spriteRenderer.flipX = moveDirection.x <= 0;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null) 
            {
                healthComponent.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        SoundPlayer.GetInstance().PlayDeathAudio();

        if (!isBlinking)
        {
            curentHealth -= damage;

            if (curentHealth <= 0)
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
        //Spawn drop
        GameObject crystalXP = CrystalPools.GetInstance().GetPooledCrystal();
        crystalXP.transform.position = transform.position;
        crystalXP.SetActive(true);
        //Spawn blood effect
        GameObject bloodEffect = BloodEffectPool.GetInstance().GetPooledBloodEffect();
        bloodEffect.transform.position = transform.position;
        bloodEffect.SetActive(true);
    
        Destroy(gameObject);
    }
}
