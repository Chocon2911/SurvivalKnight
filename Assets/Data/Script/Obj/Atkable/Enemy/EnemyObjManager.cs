using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class EnemyObjManager : HuyMonoBehaviour
{
    [Header("Enemy Obj Manager")]
    // Other
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    [SerializeField] protected EnemySO so;
    public EnemySO SO => so;

    // Script
    [SerializeField] protected EnemyObjDamageReceiver damageReceiver;
    public EnemyObjDamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected EnemyObjMovement movement;
    public EnemyObjMovement Movement => movement;

    [SerializeField] protected EnemyObjDespawn despawn;
    public EnemyObjDespawn Despawn => despawn;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRb();
        this.LoadBody();
        this.LoadSO();

        //Script
        this.LoadDamageReceiver();
        this.LoadMovement();
        this.LoadDespawn();
    }

    protected virtual void OnEnable()
    {
        this.damageReceiver.Hp = 10;
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

    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/AtkObj/Enemy/Enemy_1";
        this.so = Resources.Load<EnemySO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //Script
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<EnemyObjDamageReceiver>();
        Debug.LogWarning(transform.name + ": Load DamageReceiver", transform.gameObject);
    }

    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.Find("Movement").GetComponent<EnemyObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.Find("Despawn").GetComponent<EnemyObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Despawn", transform.gameObject);
    }
}
