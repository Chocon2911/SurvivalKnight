using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootSkillStat : WeaponSkillStat
{
    [Header("Shoot Skill Stat")]
    public string BulletName;
    public float AppearRange;
    public float BulletSpeed;
    public float BulletDespawnTime;
    public float BulletDespawnDistance;
}
