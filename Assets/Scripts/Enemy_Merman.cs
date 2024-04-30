using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Merman : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Destroy(gameObject);
    }
}
