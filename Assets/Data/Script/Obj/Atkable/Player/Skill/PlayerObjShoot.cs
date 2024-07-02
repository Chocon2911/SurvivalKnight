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

    [Header("Stat")]
    [SerializeField] protected float bulletSpeed;
    public float BulletSpeed => bulletSpeed;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSkill();
        base.LoadComponent();
    }

    protected virtual void Update()
    {
        this.Shoot();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSkill()
    {
        if (this.skill != null) return;
        this.skill = transform.parent.GetComponent<PlayerObjSkill>();
        Debug.LogWarning(transform.name + ": Load Skill", transform.gameObject);
    }

    //========================================Shoot Skill=========================================
    public override void DefaultStat()
    {
        base.DefaultStat();

        if (this.skill.Manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.bulletName = this.skill.Manager.Stat.BulletName;
        this.cooldownDelay = this.skill.Manager.Stat.ShootCooldown;
        this.cooldownTimer = 0;
        this.chargeDelay = this.skill.Manager.Stat.ShootTime;
        this.appearRad = this.skill.Manager.Stat.BulletAppearRad;
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
        this.GetNewBullet(GameManager.Instance.MousePos);
    }

    //===========================================Shoot============================================
    protected virtual void Shoot()
    {
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
