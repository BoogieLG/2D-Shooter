using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float damage, speed, lifeDuration;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetStats(PlayerController player)
    {
        damage = player.BulletDamage;
        speed = player.BulletSpeed;
        rb.velocity = player.LookDirection.normalized * speed;
    }
}
