using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BurstSkill : ShootSkill
{
    [Header("BurstSkill")]
    // Stat
    public int BulletAmount;

    [SerializeField] protected int firedBulletCount;
    public int FiredBulletCount => firedBulletCount;

    //===========================================Shoot============================================
    protected override void ChargeSkill()
    {
        this.FinishCharging();
    }

    protected override void DoSkill()
    {
        this.DoFire();
        this.DoingTimer = 0;
        if (this.firedBulletCount < this.BulletAmount) return;

        this.FinishDoing();
    }

    protected override void FinishDoing()
    {
        this.firedBulletCount = 0;
        base.FinishDoing();
    }

    protected virtual void DoFire()
    {
        Vector3 dir = this.GetDir();
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        Transform newBullet = this.GetNewBullet(spawnPos, spawnRot);
        newBullet.gameObject.SetActive(true);
    }
}
