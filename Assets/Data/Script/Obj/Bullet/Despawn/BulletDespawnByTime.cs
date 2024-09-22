using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByTime : DespawnByTime
{
    [Header("Bullet Despawn By Time")]
    [Header("Script")]
    [SerializeField] protected BulletObjDespawn bulletObjDespawn;
    public BulletObjDespawn BulletObjDespawn => bulletObjDespawn;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBulletObjDespawn();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBulletObjDespawn()
    {
        if (this.bulletObjDespawn != null) return;
        this.bulletObjDespawn = transform.parent.GetComponent<BulletObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Bullet Obj Despawn", transform.gameObject);
    }

    //=========================================Despawner==========================================
    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(this.bulletObjDespawn.transform.parent);
    }
}
