using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerSingleShoot : SingleShootSkill
{
    [Header("Player Single Shoot Skill")]
    //Other
    [SerializeField] protected PlayerSingleShootSkillSO so;
    public PlayerSingleShootSkillSO SO => so;

    // Script
    [SerializeField] protected PlayerObjWeapon playerObjWeapon;
    public PlayerObjWeapon PlayerObjWeapon => playerObjWeapon;



    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSO();
        base.LoadComponent();
        this.LoadPlayerObjWeapon();
    }

    protected virtual void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null in OnEnable");
            return;
        }

        this.SetMainObj(this.playerObjWeapon.Manager.transform);
        this.SetTargetObj(GameManager.Instance.MouseObj);
    }

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Skill/Weapon/Gun/SingleShoot/Player/M4/M4_1";
        this.so = Resources.Load<PlayerSingleShootSkillSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    // Script
    protected virtual void LoadPlayerObjWeapon()
    {
        if (this.playerObjWeapon != null) return;
        this.playerObjWeapon = transform.parent.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load PlayerObjWeapon", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        if (this.so == null)
        {
            Debug.LogError(transform.name + ": No SO", transform.gameObject);
            return;
        }

        // Base Skill
        this.CooldownDelay = this.so.CooldownDelay;
        this.ChargeDelay = this.so.ChargingDelay;
        this.DoingLength = this.so.DoingTime;
        this.CooldownTimer = 0;
        this.ChargeTimer = 0;
        this.DoingTimer = 0;

        // Weapon Skill
        this.Damage = this.so.Damage;
        this.WeaponSkillCode = this.so.WeaponSkillCode;

        // Single Shoot Skill
        this.BulletName = this.so.BulletName;
        this.BulletSpeed = this.so.BulletSpeed;
        this.AppearRange = this.so.AppearRange;
        this.BulletDespawnTime = this.so.BulletDespawnTime;
        this.BulletDespawnDistance = this.so.BulletDespawnDistance;
    }
}
