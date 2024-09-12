using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerM4Skill_1 : PlayerSingleShoot
{
    [Header("Player Single Shoot M4")]
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
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }

        SingleShootStat skillStat1 = this.gunM4.SO.Stats[0].SkillStat1;
        // Skill Stat
        this.CooldownDelay = skillStat1.CooldownDelay;
        this.ChargeDelay = skillStat1.ChargeDelay;
        this.DoingLength = skillStat1.DoingTime;

        // Weapon Skill Stat
        this.Damage = skillStat1.Damage;
        this.WeaponSkillCode = skillStat1.WeaponSkillCode;
        this.AtkObjTypes = skillStat1.AtkObjTypes;

        // Shoot Skill Stat
        this.BulletName = skillStat1.BulletName;
        this.AppearRange = skillStat1.AppearRange;
        this.BulletSpeed = skillStat1.BulletSpeed;
        this.BulletDespawnTime = skillStat1.BulletDespawnTime;
        this.BulletDespawnDistance = skillStat1.BulletDespawnDistance;
    }
}
