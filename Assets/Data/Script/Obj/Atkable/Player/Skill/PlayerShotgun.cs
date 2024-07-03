using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotgun : ShootSkill
{
    [Header("Player Shotgun")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    [Header("Stat")]
    [SerializeField] protected int pelletAmount;
    public int PelletAmount => pelletAmount;

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
    protected override void LoadMainObj()
    {
        this.mainObj = this.skill.Manager.transform;
    }

    protected override void DoShoot()
    {
        base.DoShoot();

        Vector3 dir = this.GetDir(GameManager.Instance.MousePos);
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        float spawnAngle = spawnRot.eulerAngles.z + 30/2;
        float angle = 30 / (this.pelletAmount - 1);

        for (int i = 0; i < this.pelletAmount; i++)
        {
            spawnRot.eulerAngles = new Vector3(0, 0, spawnAngle);
            this.GetNewBullet(spawnPos, spawnRot);
            spawnAngle -= angle;
            Debug.Log(transform.name + ": New Bullet", transform.gameObject);
        }
    }

    //===========================================Shoot============================================
    public virtual void Shoot()
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
