using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    //stance private et static
    private static Player instance;

    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject scythePrefab;
    [SerializeField] private float shootInterval = 3f;
    [SerializeField] private float numberProjectiles = 5;
    [SerializeField] private AudioSource attackAudio;
    
    private Vector2 mousePosition;
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
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        InvokeRepeating("Shoot", 2f, shootInterval);
    }

    void FixedUpdate()
    {
        
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
      
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;
        
        rb.MovePosition(rb.position + movement);

        //Animation
        if(movement.x != 0 || movement.y != 0) 
        {
            animPlayer.SetBool("moving", true);
        }
        else
        {
            animPlayer.SetBool("moving", false);
        }

        //sprite Direction
        if(movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
      
    }
 
    void Shoot()
    {
        attackAudio.Play();

        for(int i = 0; i < numberProjectiles; i++)
        {
            Instantiate(scythePrefab, transform.position, Quaternion.identity);
        }
    }
}
