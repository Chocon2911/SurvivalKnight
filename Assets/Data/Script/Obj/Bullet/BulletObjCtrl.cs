using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletObjCtrl : HuyMonoBehaviour
{
    [Header("Bullet Obj Ctrl")]
    [Header("Other")]
    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadBody();

        //Script
        this.LoadManager();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Transform collidedObj = collision.transform;
        if (collidedObj == null) return;

        this.CollideWithTarget(collidedObj);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadBody()
    {
        if (this.body != null) return;
        this.body = transform.GetComponent<CapsuleCollider2D>();
        this.body.isTrigger = true;
        Debug.LogWarning(transform.name + ": Load Body", transform.gameObject);
    }

    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //==========================================Collide===========================================
    public virtual void CollideWithTarget(Transform target)
    {
        DamageReceiver receiver = target.transform.GetComponentInChildren<DamageReceiver>();
        if (receiver == null) return;
        //if (receiver.AtkObjType != this.CanDamageType) return;

        this.manager.DamageSender.Send(receiver);
        this.manager.Despawn.ByTime.DespawnObj();
    }
}
