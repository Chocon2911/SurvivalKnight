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

    [SerializeField] protected Coroutine unFollowPlayerCoroutine;

    [Header("Script")]
    [SerializeField] protected EnemyObjManager mananger;
    public EnemyObjManager Mananger => mananger;

    //Get Set
    public override float MoveSpeed 
    { 
        get => this.mananger.Stat.MoveSpeed; 
        set => this.mananger.Stat.MoveSpeed = value; 
    }

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

    protected virtual void OnDisable()
    {
        this.StopAllCoroutines();
    }

    //========================================Obj Movement========================================
    protected override void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.mananger.Rb;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
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
    public virtual void DefaultStat()
    {
        if (this.mananger.Stat == null)
        {
            Debug.LogError(transform.name + ": No Stat", transform.gameObject);
            return;
        }

        this.target = null;
        this.MoveSpeed = this.mananger.Stat.MoveSpeed;
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

        if (atkObjStat.AtkObjType == AtkObjType.Player)
        {
            this.SetTarget(collision.transform);
            if (this.unFollowPlayerCoroutine == null) return;

            StopCoroutine(this.unFollowPlayerCoroutine);
        }
    }

    protected virtual void CheckIfPlayerExit(Collider2D collision)
    {
        AtkableObjStat atkObjStat = collision.transform.GetComponent<AtkableObjStat>();

        if (!transform.parent.gameObject.activeSelf) return;

        if (atkObjStat == null)
        {
            //Debug.Log(transform.name + ": No Atkable Obj Stat", transform.gameObject);
            return;
        }

        if (atkObjStat.AtkObjType == AtkObjType.Player)
        {
            if (this.unFollowPlayerCoroutine != null) StopCoroutine(this.unFollowPlayerCoroutine);
            if (!transform.parent.gameObject.activeSelf) return;
            if (!Application.isPlaying) return;
            this.unFollowPlayerCoroutine = StartCoroutine(this.UnFollowPlayer());
        }
    }

    protected virtual IEnumerator UnFollowPlayer()
    {
        yield return new WaitForSeconds(5f);
        this.SetTarget(null);
        this.UnFollow();
    }
}
