using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleGun : ShootSkill
{
    //===========================================Shoot============================================
    protected override void ChargeSkill()
    {
        this.FinishCharging();
    }

    protected override void DoSkill()
    {
        this.FinishDoing();

        Vector3 dir = this.GetDir();
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        this.GetNewBullet(spawnPos, spawnRot);
    }
}
