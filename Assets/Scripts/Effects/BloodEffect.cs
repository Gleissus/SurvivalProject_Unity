using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    private Animator animator;
    private float lifeTime = .65f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        animator.SetTrigger("PlayAnimation");        
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}
