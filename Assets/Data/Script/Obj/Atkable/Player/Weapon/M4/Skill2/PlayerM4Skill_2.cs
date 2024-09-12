using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM4Skill_2 : PlayerShotgunSkill
{
    [Header("Player Shotgun M4")]
    [SerializeField] protected PlayerGunM4 gunM4;
    public PlayerGunM4 GunM4 => gunM4;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadGunM4();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadGunM4()
    {
        if (this.gunM4 != null) return;
        this.gunM4 = transform.parent.GetComponent<PlayerGunM4>();
        Debug.LogWarning(transform.name + ": Load GunM4", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        if (this.gunM4.SO == null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        ShotgunStat skillStat2 = this.gunM4.SO.Stats[0].SkillStat2;
        // Skill Stat
        this.CooldownDelay = skillStat2.CooldownDelay;
        this.ChargeDelay = skillStat2.ChargeDelay;
        this.DoingLength = skillStat2.DoingTime;

        // Weapon Skill Stat
        this.Damage = skillStat2.Damage;
        this.WeaponSkillCode = skillStat2.WeaponSkillCode;
        this.AtkObjTypes = skillStat2.AtkObjTypes;
        
        // Shoot Skill Stat
        this.BulletName = skillStat2.BulletName;
        this.AppearRange = skillStat2.AppearRange;
        this.BulletSpeed = skillStat2.BulletSpeed;
        this.BulletDespawnTime = skillStat2.BulletDespawnTime;
        this.BulletDespawnDistance = skillStat2.BulletDespawnDistance;

        // Shotgun Stat
        this.SpreadRange = skillStat2.SpreadRange;
        this.PelletAmount = skillStat2.PelletAmount;
    }
}