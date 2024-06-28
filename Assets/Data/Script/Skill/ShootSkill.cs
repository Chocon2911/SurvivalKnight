using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootSkill : BaseSkill
{
    [Header("Shoot Skill")]
    [Header("Other")]
    [SerializeField] protected Transform mainObj;
    public Transform MainObj => mainObj;

    [Header("Stat")]
    [SerializeField] protected string bulletName;
    public string BulletName;

    [SerializeField] protected float appearRad;
    public float AppearRad => appearRad;

    [SerializeField] protected Vector3 targetPos;
    public Vector3 TargetPos => targetPos;

    //===========================================Unity============================================
    protected virtual void Update()
    {
        this.GetTargetPos();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadMainObj();
    }

    //=======================================Load Component=======================================
    protected abstract void LoadMainObj();

    //===========================================Shoot============================================
    protected virtual IEnumerator DoShoot()
    {
        Transform newBullet = this.GetNewBullet();
        if (newBullet == null) yield break;

        this.UseSkill();
        yield return new WaitForSeconds(this.chargeDelay);

        newBullet.gameObject.SetActive(true);
    }

    //============================================Get=============================================
    protected virtual Transform GetNewBullet()
    {
        if (!this.isReady) return null;

        this.UseSkill();

        Vector3 dir = this.GetDir();
        Vector3 spawnPos = this.GetSpawnPos(dir);
        Quaternion spawnRot = this.GetSpawnRot(dir);

        Transform newBullet = BulletSpawner.Instance.SpawnByName(this.bulletName, spawnPos, spawnRot);

        if (newBullet == null)
        {
            Debug.LogError(transform.name + ": New Bullet is null", transform.gameObject);
        }

        return newBullet;
    }

    protected virtual Vector3 GetSpawnPos(Vector3 dir)
    {
        return this.mainObj.transform.position + dir * this.appearRad;
    }

    protected virtual Vector3 GetDir()
    {
        return this.targetPos - this.mainObj.transform.position;
    }

    protected virtual Quaternion GetSpawnRot(Vector3 dir)
    {
        float zRot = Mathf.Tan(dir.y / dir.x);

        return new Quaternion(0, 0, zRot, 0);
    }

    //============================================Get=============================================
    protected abstract void GetTargetPos();
}
