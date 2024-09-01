using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjFly : MoveByVelocity
{
    [Header("Bullet Obj Fly")]
    [Header("Script")]
    [SerializeField] protected BulletObjMovement movement;
    public BulletObjMovement Movement => movement;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadMovement();
        base.LoadComponent();
    }
    
    protected virtual void OnEnable()
    {
        this.Move();
    }

    //=======================================Move Straight========================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<BulletObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    //============================================Move============================================
    protected override void Move()
    {
        base.Move();
        this.DoMove();
    }
}
