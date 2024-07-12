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
        this.FinshDoing();

        Vector3 dir = this.GetDir();
        Vector3 spawnPos = this.GetSpawnPos(dir);
        
    }
}
