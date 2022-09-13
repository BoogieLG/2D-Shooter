using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons")]
public class WeaponScriptableObject : ScriptableObject
{
    public WeaponType WeaponType;
    public BulletType BulletType;
    public string WeaponName;
    public float BulletDamage;
    public float BulletSpeed;
    public float BulletsPerMinute;
    public int CountOfPiercing;
    public int MaxBulletsOnBelt;

}
