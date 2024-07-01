using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [Header("Bullet Damage Sender")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    [Header("Stat")]
    [SerializeField] protected AtkObjType atkObjType;
    public AtkObjType AtkObjType => atkObjType;

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

    //=======================================Damage Sender========================================
    public override void DefaultStat()
    {
        if (this.manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.atkDamage = this.manager.Stat.Damage;
        this.atkObjType = this.manager.Stat.AtkObjType;
    }

    //==========================================Collide===========================================
    public virtual void CollideWith(Transform target)
    {
        DamageReceiver receiver = target.transform.GetComponentInChildren<DamageReceiver>();
        if (receiver == null) return;
        if (receiver.AtkObjType != this.atkObjType) return;

        this.Send(receiver);
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
