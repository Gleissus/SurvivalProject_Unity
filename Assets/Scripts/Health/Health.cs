using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float currentHealth;
    [SerializeField] float maxHealth;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float blinkDuration = .1f;

    private Color originalColor;
    private bool isBlinking = false;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = spriteRenderer.color;
        currentHealth = maxHealth;
        UIController.GetInstance().UpdateHealthBar(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        if (!isBlinking)
        {
            SoundPlayer.GetInstance().PlayHurtAudio();

            currentHealth -= amount;
            UIController.GetInstance().UpdateHealthBar(currentHealth);

            if (currentHealth <= 0)
            {
                GameController.GetInstance().GameOver();
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
        while (blinkCount < 6)
        {
            spriteRenderer.color = Color.gray;
            yield return new WaitForSeconds(blinkDuration);
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(blinkDuration);
            blinkCount++;
        }
        spriteRenderer.color = originalColor;
        isBlinking = false;
    }

}
