using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjCtrl : HuyMonoBehaviour
{
    [Header("Bullet Obj Ctrl")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Transform collidedObj = collision.transform;
        if (collidedObj == null) return;

        this.manager.DamageSender.CollideWith(collidedObj);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
