using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : ShootSkill
{
    [Header("Player Shotgun")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    //Get Set
    public override string BulletName 
    { 
        get => this.skill.Manager.Stat.ShotgunBulletName; 
        set => this.skill.Manager.Stat.ShotgunBulletName = value; 
    }

    public override float CooldownDelay
    {
        get => this.skill.Manager.Stat.ShotgunCooldown;
        set => this.skill.Manager.Stat.ShotgunCooldown = value;
    }

    public override float CooldownTimer
    {
        get => this.skill.Manager.Stat.ShotgunCooldownTimer;
        set => this.skill.Manager.Stat.ShotgunCooldownTimer = value;
    }

    public override float ChargeDelay
    {
        get => this.skill.Manager.Stat.ShotgunChargeTime;
        set => this.skill.Manager.Stat.ShotgunChargeTime = value;
    }

    public override float ChargeTimer
    {
        get => this.skill.Manager.Stat.ShotgunChargeTimer;
        set => this.skill.Manager.Stat.ShootChargeTimer = value;
    }

    public override float DoingLength
    {
        get => this.skill.Manager.Stat.ShotgunTime;
        set => this.skill.Manager.Stat.ShotgunTime = value;
    }

    public override float DoingTimer
    {
        get => this.skill.Manager.Stat.ShootTimer;
        set => this.skill.Manager.Stat.ShootTimer = value;
    }

    public float BulletSpeed
    {
        get => this.skill.Manager.Stat.ShotgunBulletSpeed;
        set => this.skill.Manager.Stat.ShotgunBulletSpeed = value;
    }

    public int PelletAmount
    {
        get => this.skill.Manager.Stat.ShotgunPelletAmount;
        set => this.skill.Manager.Stat.ShotgunPelletAmount = value;
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

    //========================================Shoot Skill=========================================
    //protected override void LoadMainObj()
    //{
    //    this.mainObj = this.skill.Manager.transform;
    //}

    //===========================================Shoot============================================
    public override void ActivateSkill()
    {
        if (!transform.gameObject.activeSelf) return;
        if (!InputManager.Instance.Shoot) return;

        base.ActivateSkill();
    }

    protected override void DoSkill()
    {
        base.DoSkill();

        Vector3 dir = this.GetDir(GameManager.Instance.MousePos);
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        float spawnAngle = spawnRot.eulerAngles.z + 30 / 2;
        float angle = 30 / (this.PelletAmount - 1);

        for (int i = 0; i < this.PelletAmount; i++)
        {
            spawnRot.eulerAngles = new Vector3(0, 0, spawnAngle);
            this.GetNewBullet(spawnPos, spawnRot);
            spawnAngle -= angle;
        }
    }
}
