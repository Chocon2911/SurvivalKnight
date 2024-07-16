using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjDespawn : HuyMonoBehaviour
{
    [Header("Bullet Obj Despawn")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    [SerializeField] protected BulletDespawnByTime byTime;
    public BulletDespawnByTime ByTime => byTime;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
        this.LoadByTime();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected virtual void LoadByTime()
    {
        if (this.byTime != null) return;
        this.byTime = transform.GetComponentInChildren<BulletDespawnByTime>();
        Debug.LogWarning(transform.name + ": Load ByTime", transform.gameObject);
    }
}
