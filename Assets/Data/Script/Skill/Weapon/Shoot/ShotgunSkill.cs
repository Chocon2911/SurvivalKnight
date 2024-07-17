using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShotgunSkill : ShootSkill
{
    [Header("Shotgun")]
    [Header("Stat")]
    public float SpreadRange;
    public int PelletAmount;

    //===========================================Shoot============================================
    public override void ActivateSkill()
    {
        if (this.PelletAmount == 0) return;
        if (this.SpreadRange > 360 || this.SpreadRange < 0)
        {
            Debug.LogError(transform.name + ": SpreadRange is not Defined (0; 360)", transform.gameObject);
            return;
        }
        base.ActivateSkill();
    }

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

        this.SpawnBullet(spawnPos, spawnRot);
    }

    //==========================================Shotgun===========================================
    protected virtual void SpawnBullet(Vector3 spawnPos, Quaternion spawnRot)
    {
        if (this.SpreadRange > 360 || this.SpreadRange < 0)
        {
            Debug.LogError(transform.name + ": SpreadRange is not Defined (0; 360)", transform.gameObject);
            return;
        }

        float spawnAngle = spawnRot.eulerAngles.z + this.SpreadRange / 2;
        float angle = this.SpreadRange / (this.PelletAmount - 1);

        for (int i = 0; i < this.PelletAmount; i++)
        {
            spawnRot.eulerAngles = new Vector3(0, 0, spawnAngle);
            this.GetNewBullet(spawnPos, spawnRot);
            spawnAngle -= angle;
        }
    }
}
