using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletObjMovement : HuyMonoBehaviour
{
    [Header("Bullet Obj Movement")]
    [Header("Script")]
    [SerializeField] protected BulletObjManager manager;
    public BulletObjManager Manager => manager;

    [SerializeField] protected BulletObjFly fly;
    public BulletObjFly Fly => fly;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadManager();
        this.LoadFly();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<BulletObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager");
    }
    
    protected virtual void LoadFly()
    {
        if (this.fly != null) return;
        this.fly = transform.GetComponentInChildren<BulletObjFly>();
        Debug.LogWarning(transform.name + ": Load Fly", transform.gameObject);
    }
}
