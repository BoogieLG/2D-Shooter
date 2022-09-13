using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float maxHealth = 10f;
    private float currentHealth;
    private Transform target;
    private float movingSpeed =3f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
        moveToTarget();
    }
    private void moveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movingSpeed * Time.fixedDeltaTime );
    }

    public void TakeDamage(WeaponComponent weaponComponent)
    {
        currentHealth -= weaponComponent.BulletDamage;
        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
