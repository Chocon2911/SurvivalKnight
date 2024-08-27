using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunSkillSO : WeaponSkillSO
{
    [Header("Gun Skill SO")]
    public string BulletName;
    public float BulletSpeed;
    public float AppearRange;
    public float BulletDespawnTime;
    public float BulletDespawnDistance;
}
