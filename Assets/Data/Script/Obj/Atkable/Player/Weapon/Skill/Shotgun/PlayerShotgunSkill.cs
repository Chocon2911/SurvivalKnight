using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgunSkill : ShotgunSkill
{
    [Header("Player Shotgun Skill")]
    // Script
    [SerializeField] protected PlayerShotgunSkillSO so;
    public PlayerShotgunSkillSO SO => so;

    [SerializeField] protected PlayerObjWeapon playerObjWeapon;
    public PlayerObjWeapon PlayerObjWeapon => playerObjWeapon;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSO();
        base.LoadComponent();
        // Script
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
    // Script
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Skill/Weapon/Gun/Shotgun/Player/M4/M4_1";
        this.so = Resources.Load<PlayerShotgunSkillSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    protected virtual void LoadPlayerObjWeapon()
    {
        if (this.playerObjWeapon != null) return;
        this.playerObjWeapon = transform.parent.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load PlayerObjWeapon", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        if (this.so == null)
        {
            Debug.Log(transform.name + ": SO is null", transform.gameObject);
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
        this.weaponSkillCode = this.so.WeaponSkillCode;

        // Gun Skill
        this.BulletName = this.so.BulletName;
        this.BulletSpeed = this.so.BulletSpeed;
        this.AppearRange = this.so.AppearRange;
        this.BulletDespawnTime = this.so.BulletDespawnTime;
        this.BulletDespawnDistance = this.so.BulletDespawnDistance;

        // Shotgun Skill
        this.SpreadRange = this.so.SpreadRange;
        this.PelletAmount = this.so.PelletAmount;
    }
}
