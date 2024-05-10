using System.Collections;
using UnityEngine;

public class Enemy_Fly : Enemy_BASE
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject shootDirection;
    [SerializeField] private float minDistance = 3f;
    [SerializeField] private float attackCooldown = 2f;

    private void Start()
    {
        base.Start();

        StartCoroutine(AttackCourotine());
    }
   
    public override void Move()
    {
        Vector2 moveDirection = target.position - transform.position;

       
        if (moveDirection.magnitude > minDistance)
        {
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(-moveDirection.normalized * speed * Time.deltaTime);
        }

        // Flip sprite
        base.spriteRenderer.flipX = moveDirection.x <= 0;

        // Rotate towards the player
        Vector2 lookDirection = base.target.position - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        shootDirection.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator AttackCourotine()
    {
        while(true)
        {
            yield return new WaitForSeconds(attackCooldown);

            // Instantiate projectile
            GameObject projectile = Instantiate(projectilePrefab, transform.position, shootDirection.transform.rotation);           
        }
    }

}
