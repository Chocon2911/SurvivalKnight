using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBy15Skill_2 : PlayerShotgunSkill
{
    [Header("Player By15 Skill_2")]
    [SerializeField] protected PlayerGunBy15 gunBy15;
    public PlayerGunBy15 GunBy15 => gunBy15;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadGun15();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadGun15()
    {
        if (this.gunBy15 != null) return;
        this.gunBy15 = transform.parent.GetComponent<PlayerGunBy15>();
        Debug.LogWarning(transform.name + ": Load Gun15", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();

        if (this.gunBy15.SO == null)
        {
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }

        ShotgunStat skillStat_2 = this.gunBy15.SO.Stat.skill_2;

        // Skill Stat
        this.CooldownDelay = skillStat_2.CooldownDelay;
        this.ChargeDelay = skillStat_2.ChargeDelay;
        this.DoingLength = skillStat_2.DoingTime;

        // Weapon Skill Stat
        this.Damage = skillStat_2.Damage;
        this.WeaponSkillCode = skillStat_2.WeaponSkillCode;
        this.AtkObjTypes = skillStat_2.AtkObjTypes;

        // Shoot Skill Stat
        this.BulletName = skillStat_2.BulletName;
        this.AppearRange = skillStat_2.AppearRange;
        this.BulletSpeed = skillStat_2.BulletSpeed;
        this.BulletDespawnTime = skillStat_2.BulletDespawnTime;
        this.BulletDespawnDistance = skillStat_2.BulletDespawnDistance;

        // Shotgun Stat
        this.SpreadRange = skillStat_2.SpreadRange;
        this.PelletAmount = skillStat_2.PelletAmount;
    }
}
