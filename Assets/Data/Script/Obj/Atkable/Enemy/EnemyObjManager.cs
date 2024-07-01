using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyObjManager : HuyMonoBehaviour
{
    [Header("Enemy Obj Manager")]
    [Header("Other")]
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    [Header("Script")]
    [SerializeField] protected EnemyObjStat stat;
    public EnemyObjStat Stat => stat;

    [SerializeField] protected EnemyObjMovement movement;
    public EnemyObjMovement Movement => movement;

    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    public EnemyDamageReceiver DamageReceiver => damageReceiver;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRb();
        this.LoadBody();

        //Script
        this.LoadStat();
        this.LoadMovement();
        this.LoadDamageReceiver();
    }

    protected virtual void OnEnable()
    {
        this.stat.DefaultStat();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    protected virtual void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.gravityScale = 0;
        this.rb.mass = 0.1f;
        this.rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected virtual void LoadBody()
    {
        if (this.body != null) return;
        this.body = transform.GetComponent<CapsuleCollider2D>();
        this.body.isTrigger = false;
        this.body.size = new Vector2(1, 1);
        Debug.LogWarning(transform.name + ": Load Body", transform.gameObject);
    }

    //Script
    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<EnemyObjStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<EnemyObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<EnemyDamageReceiver>();
        Debug.LogWarning(transform.name + ": Load DamageReceiver", transform.gameObject);
    }
}
