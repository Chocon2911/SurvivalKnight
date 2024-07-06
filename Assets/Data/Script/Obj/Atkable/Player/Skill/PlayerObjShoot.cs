using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerObjShoot : ShootSkill
{
    [Header("Player Obj Shoot")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    //Get Set
    public override string BulletName 
    { 
        get => this.skill.Manager.Stat.BulletName; 
        set => this.skill.Manager.Stat.BulletName = value; 
    }

    public override float CooldownDelay 
    { 
        get => this.skill.Manager.Stat.ShootCooldown; 
        set => this.skill.Manager.Stat.ShootCooldown = value; 
    }

    public override float CooldownTimer 
    { 
        get => this.skill.Manager.Stat.ShootCooldownTimer; 
        set => this.skill.Manager.Stat.ShootCooldownTimer = value; 
    }

    public override float ChargeDelay 
    { 
        get => this.skill.Manager.Stat.ShootChargeTime; 
        set => this.skill.Manager.Stat.ShootChargeTime = value; 
    }

    public override float ChargeTimer 
    {
        get => this.skill.Manager.Stat.ShootChargeTimer;
        set => this.skill.Manager.Stat.ShootChargeTimer = value;
    }

    public override float DoingLength 
    { 
        get => this.skill.Manager.Stat.ShootTime; 
        set => this.skill.Manager.Stat.ShootTime = value; 
    }

    public override float DoingTimer 
    { 
        get => this.skill.Manager.Stat.ShootTimer; 
        set => this.skill.Manager.Stat.ShootTimer = value; 
    }

    public float BulletSpeed
    {
        get => this.skill.Manager.Stat.BulletSpeed;
        set => this.skill.Manager.Stat.BulletSpeed = value;
    }

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSkill();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSkill()
    {
        if (this.skill != null) return;
        this.skill = transform.parent.GetComponent<PlayerObjSkill>();
        Debug.LogWarning(transform.name + ": Load Skill", transform.gameObject);
    }

    protected override void LoadMainObj()
    {
        if (this.mainObj != null) return;
        this.mainObj = this.skill.Manager.transform;
        Debug.LogWarning(transform.name + ": Load MainObj", transform.gameObject);
    }

    protected override void DoShoot()
    {
        base.DoShoot();

        Vector3 dir = this.GetDir(GameManager.Instance.MousePos);
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        this.GetNewBullet(spawnPos, spawnRot);
    }

    //===========================================Shoot============================================
    public virtual void Shoot()
    {
        if (!transform.gameObject.activeSelf) return;

        if (this.isReady && InputManager.Instance.Shoot)
        {
            this.UseSkill();
        }

        if (this.isCharging)
        {
            this.ChargeShoot();
        }

        if (this.isDoing)
        {
            this.DoShoot();
        }
    }
}
