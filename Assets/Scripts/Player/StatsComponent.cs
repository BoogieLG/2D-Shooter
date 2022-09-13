using UnityEngine;

public class StatsComponent : MonoBehaviour
{
    private float health, speed, bulletDamage, bulletSpeed, bulletFireRate, bulletCapacity;

    public float Health => health;
    public float Speed => speed;
    public float BulletDamage => bulletDamage;
    public float BulletSpeed => bulletSpeed;
    public float BulletFireRate => bulletFireRate;
    public float BulletCapacity => bulletCapacity;

    private void Start()
    {
        health = 10f;
        speed = 10f;
        bulletSpeed = 10f;
    }
}
