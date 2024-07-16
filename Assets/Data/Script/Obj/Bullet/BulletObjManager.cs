using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletObjManager : HuyMonoBehaviour
{
    [Header("Bullet Obj Manager")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [Header("Script")]
    [SerializeField] protected BulletObjCtrl ctrl;
    public BulletObjCtrl Ctrl => ctrl;

    [SerializeField] protected BulletObjMovement movement;
    public BulletObjMovement Movement => movement;

    [SerializeField] protected BulletObjDespawn despawn;
    public BulletObjDespawn Despawn => despawn;

    [SerializeField] protected BulletDamageSender damageSender;
    public BulletDamageSender DamageSender => damageSender;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadRb();
        this.LoadModel();

        //Script
        this.LoadCtrl();
        this.LoadMovement();
        this.LoadDespawn();
        this.LoadDamageSender();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    //Script
    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<BulletObjCtrl>();
        Debug.LogWarning(transform.name + ": Load Ctrl", transform.gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<BulletObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<BulletObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Despawn", transform.gameObject);
    }

    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.LogWarning(transform.name + ": Load DamageSender", transform.gameObject);
    }
}
