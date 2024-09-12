using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObjFly : MoveByVelocity
{
    [Header("Bullet Obj Fly")]
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
        this.canMove = true;
    }

    //=======================================Move Straight========================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected override void Execute()
    {
        this.DoMove();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<BulletObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }
}
