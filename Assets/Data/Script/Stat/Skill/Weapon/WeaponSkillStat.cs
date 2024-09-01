using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSkillStat : SkillStat
{
    [Header("Weapon Skill Stat")]
    public float Damage;
    public WeaponSkillCode WeaponSkillCode;
}
