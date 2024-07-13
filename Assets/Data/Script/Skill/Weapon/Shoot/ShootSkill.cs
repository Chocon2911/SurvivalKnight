using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootSkill : WeaponSkill
{
    [Header("Shoot Skill")]
    [Header("Other")]
    [SerializeField] protected Transform mainObj;
    public Transform MainObj => mainObj;

    [SerializeField] protected Transform targetObj;
    public Transform TargetObj => targetObj;

    //==========================================Get Set===========================================
    public string BulletName;
    public float AppearRad;

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
}
