using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyObjMovement : ObjFollowTargetByVelocity
{
    [Header("Enemy Obj Movement")]
    [Header("Other")]
    [SerializeField] protected CircleCollider2D detectEnemy;
    public CircleCollider2D DetectEnemy => detectEnemy;

    [SerializeField] protected Coroutine UnfollowPlayerCoroutine;

    [Header("Script")]
    [SerializeField] protected EnemyObjManager mananger;
    public EnemyObjManager Mananger => mananger;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        //Script
        this.LoadManager();
        
        //Other
        this.LoadDetectEnemy();
        base.LoadComponent();
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.CheckIfPlayerEnter(collision);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        this.CheckIfPlayerExit(collision);
    }

    //========================================Obj Movement========================================
    protected override void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.mananger.Rb;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    protected override void LoadAtkableObjStat()
    {
        if (this.atkableObjStat != null) return;
        this.atkableObjStat = this.mananger.Stat;
        Debug.LogWarning(transform.name + ": Load AtkableOBjStat", transform.gameObject);
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadDetectEnemy()
    {
        if (this.detectEnemy != null) return;
        this.detectEnemy = transform.GetComponent<CircleCollider2D>();
        this.detectEnemy.isTrigger = true;
        Debug.LogWarning(transform.name + ": Load DetectEnemy", transform.gameObject);
    }

    //Script
    protected virtual void LoadManager()
    {
        if (this.mananger != null) return;
        this.mananger = transform.parent.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //===========================================Other============================================
    public override void DefaultStat()
    {
        base.DefaultStat();

        this.detectEnemy.radius = this.mananger.Stat.DetectRange;
        //Debug.Log(transform.name + ": Load DefaultStat", transform.gameObject);
    }

    //=======================================Detect Player========================================
    protected virtual void CheckIfPlayerEnter(Collider2D collision)
    {
        AtkableObjStat atkObjStat = collision.transform.GetComponent<AtkableObjStat>();

        if (atkObjStat == null)
        {
            //Debug.Log(transform.name + ": No Atkable Obj Stat", transform.gameObject);
            return;
        }

        if (atkObjStat.AtkObjType != AtkObjType.Player)
        {
            this.SetTarget(collision.transform);
            StopCoroutine(this.UnFollowPlayer());
        }
    }

    protected virtual void CheckIfPlayerExit(Collider2D collision)
    {
        AtkableObjStat atkObjStat = collision.transform.GetComponent<AtkableObjStat>();

        if (atkObjStat == null)
        {
            //Debug.Log(transform.name + ": No Atkable Obj Stat", transform.gameObject);
            return;
        }

        if (atkObjStat.AtkObjType != AtkObjType.Player)
        {
            if (this.UnfollowPlayerCoroutine != null) StopCoroutine(this.UnfollowPlayerCoroutine);
            this.UnfollowPlayerCoroutine = StartCoroutine(this.UnFollowPlayer());
        }
    }

    protected virtual IEnumerator UnFollowPlayer()
    {
        yield return new WaitForSeconds(5f);
        this.SetTarget(null);
        this.UnFollow();
    }
}
