using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] protected bool isShoot;
    public bool IsShoot => isShoot;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSkill();
        base.LoadComponent();
    }

    protected override void Update()
    {
        base.Update();
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

        this.cooldownDelay = this.skill.Manager.Stat.ShootCooldown;
        this.cooldownTimer = 0;
        this.chargeDelay = this.skill.Manager.Stat.ShootTime;
        this.isShoot = false;
    }

    protected override void LoadMainObj()
    {
        if (this.mainObj != null) return;
        this.mainObj = this.skill.Manager.transform;
        Debug.LogWarning(transform.name + ": Load MainObj", transform.gameObject);
    }

    protected override void GetTargetPos()
    {
        this.targetPos = GameManager.Instance.MousePos;
    }

    //==========================================Checker===========================================
    protected virtual void CheckIfShoot()
    {
        this.isShoot = InputManager.Instance.Shoot;
    }

    //===========================================Shoot============================================
    protected virtual void Shoot()
    {
        if (!this.isShoot) return;

        StartCoroutine(this.DoShoot());
        //Add any charge Anim here;
    }
}
