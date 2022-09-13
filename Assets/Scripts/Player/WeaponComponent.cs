using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject primaryWeapon;
    private WeaponScriptableObject currentWeapon;

    private float timerNextBullet = 0f;
    public string WeaponName => currentWeapon.WeaponName;
    public WeaponType WeaponType => currentWeapon.WeaponType;

    public BulletType BulletType => currentWeapon.BulletType;

    public float BulletDamage => currentWeapon.BulletDamage;

    public float BulletSpeed => currentWeapon.BulletSpeed;
    public float BulletsPerMinute => currentWeapon.BulletsPerMinute;
    public int CountOfPiercing => currentWeapon.CountOfPiercing;
    public int MaxBulletsOnBelt => currentWeapon.MaxBulletsOnBelt;

    private int currentBulletsOnBelt;
    private void Start()
    {
        SetPrimaryWeapon();
    }
    private void FixedUpdate()
    {
        timerNextBullet -= Time.fixedDeltaTime;
    }
    public void ChangeWeapon(WeaponScriptableObject newWeapon)
    {
        currentWeapon = newWeapon;
        currentBulletsOnBelt = newWeapon.MaxBulletsOnBelt;
    }
    private void SetPrimaryWeapon()
    {
        ChangeWeapon(primaryWeapon);
    }
    public void MakeFire()
    {
        if (timerNextBullet <= 0f)
        {
            ObjectPooler.instance.SpawnFromPool(BulletType.Simple, transform.position, this);
            timerNextBullet = 60 / BulletsPerMinute;
            checkForBullets();
        }
    }

    private void checkForBullets()
    {
        currentBulletsOnBelt--;
        if (currentBulletsOnBelt <= 0)
        {
            SetPrimaryWeapon();
        }
    }

}
