using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootSkill : BaseSkill
{
    [Header("Shoot Skill")]
    [Header("Other")]
    [SerializeField] protected Transform mainObj;
    public Transform MainObj => mainObj;

    //==========================================Get Set===========================================
    public virtual string BulletName {  get; set; }
    public virtual float AppearRad { get; set; }

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainObj();
    }

    //=======================================Load Component=======================================
    protected abstract void LoadMainObj();

    //===========================================Shoot============================================
    protected virtual void DoShoot()
    {
        this.isDoing = false;
        //Debug.Log("Do Shoot", transform.gameObject);
    }

    protected virtual void ChargeShoot()
    {
        this.isCharging = false;
        this.isDoing = true;
        //Debug.Log("Charge", transform.gameObject);
    }

    //============================================Get=============================================
    protected virtual void GetNewBullet(Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newBullet = BulletSpawner.Instance.SpawnByName(this.BulletName, spawnPos, spawnRot);

        if (newBullet == null)
        {
            Debug.LogError(transform.name + ": New Bullet is null", transform.gameObject);
            return;
        }

        newBullet.gameObject.SetActive(true);
    }

    protected virtual Vector3 GetSpawnPos(Vector3 dir)
    {
        return this.mainObj.transform.position + dir.normalized * this.AppearRad;
    }

    protected virtual Vector3 GetDir(Vector3 targetPos)
    {
        return (targetPos - this.mainObj.transform.position);
    }

    protected virtual Quaternion GetSpawnRot(Vector3 dir)
    {
        float zRot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log("ZRot: " + zRot, transform.gameObject);
        Quaternion spawnRot = Quaternion.Euler(0, 0, zRot);

        return spawnRot;
    }
}
