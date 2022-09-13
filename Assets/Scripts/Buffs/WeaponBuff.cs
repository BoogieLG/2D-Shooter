using UnityEngine;

public class WeaponBuff : Buff
{
    [SerializeField] private WeaponScriptableObject weapon;
    private WeaponComponent weaponComponent;
    protected override void doAction()
    {
        weaponComponent.ChangeWeapon(weapon);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            weaponComponent = collision.GetComponent<WeaponComponent>();
            doAction();
            Destroy(gameObject);
        }
    }
}
