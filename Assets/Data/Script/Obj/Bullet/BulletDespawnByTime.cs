using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnByTime : DespawnByTime
{
    [Header("Bullet Despawn By Time")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //Get Set
    public override float DespawnDelay 
    { 
        get => this.manager.Stat.ExistTime; 
        set => this.manager.Stat.ExistTime = value; 
    }

    public override float DespawnTimer 
    {
        get => this.manager.Stat.ExistTimer; 
        set => this.manager.Stat.ExistTimer = value; 
    }

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //=========================================Despawner==========================================
    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
