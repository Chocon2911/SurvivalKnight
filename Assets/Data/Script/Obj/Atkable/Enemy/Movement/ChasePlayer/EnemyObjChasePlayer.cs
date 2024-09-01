using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjChasePlayer : FollowTargetVelocity
{
    [Header("Enemy Obj Chase Player")]
    [SerializeField] protected EnemyObjMovement movement;
    public EnemyObjMovement Movement => movement;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadMovement();
        base.LoadComponent();
    }

    //===================================Follow Target Velocity===================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<EnemyObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }
}
