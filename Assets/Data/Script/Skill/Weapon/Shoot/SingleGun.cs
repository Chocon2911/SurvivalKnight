using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGun : ShootSkill
{
    //===========================================Shoot============================================
    protected override void ChargeSkill()
    {
        this.FinishCharging();
    }

    protected override void DoSkill()
    {
        if (this.targetObj == null || this.mainObj == null)
        {
            Debug.LogError("target or main obj are null", transform.gameObject);
        }

        this.FinshDoing();

        Vector3 dir = this.GetDir();
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        this.GetNewBullet(spawnPos, spawnRot);
    }
}
