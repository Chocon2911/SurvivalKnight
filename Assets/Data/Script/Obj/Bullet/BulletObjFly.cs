using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjFly : ObjFlyStraight
{
    [Header("Bullet Obj Fly")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //Get Set
    public override float FlySpeed
    {
        get => this.manager.Stat.FlySpeed;
        set => this.manager.Stat.FlySpeed = value;
    }

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    protected override void OnEnable() { }

    //======================================Obj Fly Straight======================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = transform.parent.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = true;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected override void LoadAffectedObj()
    {
        if (this.affectedObj != null) return;
        this.affectedObj = transform.parent;
        Debug.LogWarning(transform.name + ": Load AfftectedObj", transform.gameObject);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
