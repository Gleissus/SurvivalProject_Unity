using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class SurikenWeapon : MonoBehaviour
{
    private static SurikenWeapon instance;

    [SerializeField] GameObject playerPosition;
    [SerializeField] private float radius = 2f;
    [SerializeField] private float speed = 3f;

    private SpriteRenderer sprite;
    private float angle;
    private float increaseLevelRate = .3f;

    public static SurikenWeapon GetInstance() => instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {        
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {         
        angle += speed * Time.deltaTime;
     
        Vector2 centerPosition = playerPosition.transform.position;
        Vector2 offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * radius;
        transform.position = centerPosition + offset;
    }

    public void LevelUpdate()
    {
        speed += speed * increaseLevelRate;
        sprite.transform.localScale += sprite.transform.localScale * increaseLevelRate;
    }

}

