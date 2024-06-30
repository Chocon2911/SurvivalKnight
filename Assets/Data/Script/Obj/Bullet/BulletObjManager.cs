using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class BulletObjManager : HuyMonoBehaviour
{
    [Header("Bullet Obj Manager")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [Header("Script")]
    [SerializeField] protected BulletObjFly fly;
    public BulletObjFly Fly => fly;

    [SerializeField] protected BulletObjStat stat;
    public BulletObjStat Stat => stat;

    [SerializeField] protected BulletDespawnByTime despawnByTime;
    public BulletDespawnByTime DespawnByTime => despawnByTime;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadRb();
        this.LoadBody();
        this.LoadModel();

        //Script
        this.LoadFly();
        this.LoadStat();
        this.LoadDespawnByTime();
    }

    protected virtual void OnEnable()
    {
        this.stat.DefaultStat();
        this.fly.Fly();
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

    protected virtual void LoadBody()
    {
        if (this.body != null) return;
        this.body = transform.GetComponent<CapsuleCollider2D>();
        Debug.LogWarning(transform.name + ": Load Body", transform.gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    //Script
    protected virtual void LoadFly()
    {
        if (this.fly != null) return;
        this.fly = transform.GetComponentInChildren<BulletObjFly>();
        Debug.LogWarning(transform.name + ": Load Fly", transform.gameObject);
    }

    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<BulletObjStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }

    protected virtual void LoadDespawnByTime()
    {
        if (this.despawnByTime != null) return;
        this.despawnByTime = transform.GetComponentInChildren<BulletDespawnByTime>();
        Debug.LogWarning(transform.name + ": Load DespawnByTime", transform.gameObject);
    }
}
