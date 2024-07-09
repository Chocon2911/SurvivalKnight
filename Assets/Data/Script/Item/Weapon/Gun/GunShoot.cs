using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : ShootSkill
{
    [Header("Gun Shoot")]
    [Header("Script")]
    [SerializeField] protected GunManager manager;
    public GunManager Manager => manager;

    #region Get Set
    //Get Set
    public override string BulletName
    {
        get => this.manager.Stat.BulletName;
        set => this.manager.Stat.BulletName = value;
    }

    public override float CooldownDelay
    {
        get => this.manager.Stat.ShootCooldown;
        set => this.manager.Stat.ShootCooldown = value;
    }

    public override float CooldownTimer
    {
        get => this.manager.Stat.ShootCooldownTimer;
        set => this.manager.Stat.ShootCooldownTimer = value;
    }

    public override float ChargeDelay
    {
        get => this.manager.Stat.ShootChargeTime;
        set => this.manager.Stat.ShootChargeTime = value;
    }

    public override float ChargeTimer
    {
        get => this.manager.Stat.ShootChargeTimer;
        set => this.manager.Stat.ShootChargeTimer = value;
    }

    public override float DoingLength
    {
        get => this.manager.Stat.ShootTime;
        set => this.manager.Stat.ShootTime = value;
    }

    public override float DoingTimer
    {
        get => this.manager.Stat.ShootTimer;
        set => this.manager.Stat.ShootTimer = value;
    }

    public float BulletSpeed
    {
        get => this.manager.Stat.BulletSpeed;
        set => this.manager.Stat.BulletSpeed = value;
    }
    #endregion

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //========================================Shoot Skill=========================================
    protected override void LoadMainObj()
    {

    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<GunManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //===========================================Shoot============================================
    public override void ActivateSkill()
    {
        if (!transform.gameObject.activeSelf) return;
        base.ActivateSkill();
    }

    protected override void DoSkill()
    {
        base.DoSkill();

        Vector3 dir = this.GetDir(GameManager.Instance.MousePos);
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        this.GetNewBullet(spawnPos, spawnRot);
    }
}
