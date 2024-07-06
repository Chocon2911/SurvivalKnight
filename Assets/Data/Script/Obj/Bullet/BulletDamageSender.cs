using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //Get Set
    public override float AtkDamage 
    { 
        get => this.manager.Stat.Damage; 
        set => this.manager.Stat.Damage = value; 
    }
    public AtkObjType CanDamageType
    {
        get => this.manager.Stat.CanDamageType;
        set => this.manager.Stat.CanDamageType = value;
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

    //==========================================Collide===========================================
    public virtual void CollideWith(Transform target)
    {
        DamageReceiver receiver = target.transform.GetComponentInChildren<DamageReceiver>();
        if (receiver == null) return;
        if (receiver.AtkObjType != this.CanDamageType) return;

        this.Send(receiver);
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
