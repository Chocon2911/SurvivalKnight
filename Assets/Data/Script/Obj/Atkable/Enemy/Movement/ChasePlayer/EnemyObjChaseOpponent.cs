using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class EnemyObjChaseOpponent : FollowTargetPosVelocity
{
    [Header("Enemy Obj Chase Player")]
    //Other
    [SerializeField] protected CircleCollider2D detectCollide;
    public CircleCollider2D DetectCollide => detectCollide;

    [SerializeField] protected List<AtkObjType> opponents;
    public List<AtkObjType> Opponents => opponents;

    // Script
    [SerializeField] protected EnemyObjMovement movement;
    public EnemyObjMovement Movement => movement;

    [SerializeField] protected AtkableObjStat atkObjStat;
    public AtkableObjStat AtkObjStat => atkObjStat;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        //Other
        this.LoadDetectCollide();

        //Script
        this.LoadMovement();
        base.LoadComponent();
    }

    protected virtual void OnEnable()
    {
        this.canMove = true;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.atkObjStat != null) return;

        this.atkObjStat = collision.transform.GetComponent<AtkableObjStat>();
        if (atkObjStat == null) return;

        this.CheckIfCollideOpponent();
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (this.atkObjStat == null) return;
        if (collision.transform != atkObjStat.transform) return;
        this.atkObjStat = null;
        this.target = null;
    }

    //===================================Follow Target Velocity===================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadDetectCollide()
    {
        if (this.detectCollide != null) return;
        this.detectCollide = transform.GetComponent<CircleCollider2D>();
        Debug.LogWarning(transform.name + ": Load DetectCollide", transform.gameObject);
    }

    // Script
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<EnemyObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    //==========================================Collide===========================================
    protected virtual void CheckIfCollideOpponent()
    {
        foreach (AtkObjType opponent in this.opponents)
        {
            if (this.target != null) break;
            if (opponent != this.atkObjStat.AtkObjType) continue;

            this.target = this.atkObjStat.transform;
            Debug.Log(transform.name + ": Collide atkObj", transform.gameObject);
        }
    }
}
