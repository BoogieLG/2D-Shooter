using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private WeaponComponent weaponComponent;
    private Rigidbody2D rb;

    private int countOfPiercing;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetStats(WeaponComponent wpComp)
    {
        weaponComponent = wpComp;
        rb.velocity = weaponComponent.GetComponentInParent<PlayerController>().LookDirection.normalized * weaponComponent.BulletSpeed;
        countOfPiercing = wpComp.CountOfPiercing;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Enemy") return;
        collision.TryGetComponent<EnemyController>(out EnemyController enemyController);
        enemyController.TakeDamage(weaponComponent);
        if (countOfPiercing <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            countOfPiercing--;
        }
    }

    
}
