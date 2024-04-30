using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheAttack : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Vector2 screenBounds;
    private Vector2 mousePosition;
    private Vector2 scytheDirection;

    public Vector2 direction = Vector2.right;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        scytheDirection = (mousePosition - (Vector2)transform.position).normalized;

        transform.right = scytheDirection;
    }

    void Update()
    {       

        transform.Translate(scytheDirection * speed * Time.deltaTime);

        if(transform.position.x > screenBounds.x)
        {
            Destroy(gameObject);
        }
    }


}
