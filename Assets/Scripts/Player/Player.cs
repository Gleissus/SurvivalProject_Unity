using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    //stance private et static
    private static Player instance;

    [SerializeField] private float speed = 5f;    
    
    private Rigidbody2D rb;
    private Animator animPlayer;
    private SpriteRenderer spriteRenderer;

    //Acces public a l'instance à traves uns méthode static
    public static Player GetInstance() => instance;
    private void Awake()
    {
        instance = this;
        animPlayer = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();              
    }

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
      
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;
        
        rb.MovePosition(rb.position + movement);

        // Animation
        animPlayer.SetBool("moving", (movement.x != 0 || movement.y != 0));

        // Sprite Sprite
        spriteRenderer.flipX = (movement.x < 0) ? true : (movement.x > 0) ? false : spriteRenderer.flipX;

    }
}
