using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBy15Skill_1 : PlayerShotgunSkill
{
    [Header("Player By15 Skill_1")]
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

        ShotgunStat skillStat_1 = this.gunBy15.SO.Stat.skill_1;
        
        // Skill Stat
        this.CooldownDelay = skillStat_1.CooldownDelay;
        this.ChargeDelay = skillStat_1.ChargeDelay;
        this.DoingLength = skillStat_1.DoingTime;

        // Weapon Skill Stat
        this.Damage = skillStat_1.Damage;   
        this.WeaponSkillCode = skillStat_1.WeaponSkillCode;
        this.AtkObjTypes = skillStat_1.AtkObjTypes;

        // Shoot Skill Stat
        this.BulletName = skillStat_1.BulletName;
        this.AppearRange = skillStat_1.AppearRange;
        this.BulletSpeed = skillStat_1.BulletSpeed;
        this.BulletDespawnTime = skillStat_1.BulletDespawnTime;
        this.BulletDespawnDistance = skillStat_1.BulletDespawnDistance;

        // Shotgun Stat
        this.SpreadRange = skillStat_1.SpreadRange;
        this.PelletAmount = skillStat_1.PelletAmount;
    }
}
