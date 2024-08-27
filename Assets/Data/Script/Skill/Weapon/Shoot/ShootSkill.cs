using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootSkill : WeaponSkill
{
    [Header("Shoot Skill")]
    // Other
    [SerializeField] protected Transform mainObj;
    public Transform MainObj => mainObj;

    [SerializeField] protected Transform targetObj;
    public Transform TargetObj => targetObj;

    // Script
    [SerializeField] protected BulletDataSender bulletSender;
    public BulletDataSender BulletSender => bulletSender;

    // Stat
    public string BulletName;
    public float AppearRange;
    public float BulletSpeed;
    public float BulletDespawnTime;
    public float BulletDespawnDistance;



    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletSender();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBulletSender()
    {
        if (this.bulletSender != null) return;
        this.bulletSender = transform.GetComponentInChildren<BulletDataSender>();
        Debug.LogWarning(transform.name + ": Load BulletSender", transform.gameObject);
    }

    //============================================Set=============================================
    public virtual void SetMainObj(Transform mainObj)
    {
        this.mainObj = mainObj;
    }

    public virtual void SetTargetObj(Transform targetObj)
    {
        this.targetObj = targetObj;
    }

    //============================================Get=============================================
    protected virtual Transform GetNewBullet(Vector3 spawnPos, Quaternion spawnRot)
    {
        Transform newBullet = BulletSpawner.Instance.SpawnByName(this.BulletName, spawnPos, spawnRot);

        if (newBullet == null)
        {
            Debug.LogError(transform.name + ": New Bullet is null", transform.gameObject);
            return null;
        }

        BulletObjManager bulletObjManager = newBullet.GetComponentInChildren<BulletObjManager>();

        if (bulletObjManager == null)
        {
            Debug.LogError(transform.name + ": Bullet Obj Manager is null", transform.gameObject);
            return null;
        }

        this.bulletSender.DefaultStat(this.Damage, this.BulletSpeed, this.BulletDespawnTime, this.BulletDespawnDistance);
        this.bulletSender.Send(bulletObjManager.BulletDataReceiver);

        return newBullet;
    }

    protected virtual Vector3 GetSpawnPos(Vector3 dir)
    {
        return this.mainObj.transform.position + dir.normalized * this.AppearRange;
    }

    protected virtual Vector3 GetDir()
    {
        return (this.targetObj.position - this.mainObj.position).normalized;
    }

    protected virtual Quaternion GetSpawnRot(Vector3 dir)
    {
        float zRot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //Debug.Log("ZRot: " + zRot, transform.gameObject);
        Quaternion spawnRot = Quaternion.Euler(0, 0, zRot);

        return spawnRot;
    }

    //===========================================Shoot============================================
    protected override void DoSkill()
    {
        if (this.targetObj == null || this.mainObj == null)
        {
            Debug.LogError("Target or main obj are null", transform.gameObject);
            return;
        }
    }
}
