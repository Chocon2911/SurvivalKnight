using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveByKeyBoard : MoveByVelocity
{
    [SerializeField] protected PlayerObjMovement movement;
    public PlayerObjMovement Movement => movement;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadMovement();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<PlayerObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    //======================================Move By Velocity======================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected override void Move()
    {
        this.DoMove();
    }

    protected override void DoMove()
    {
        this.moveDir = InputManager.Instance.MoveDir;
        base.DoMove();
    }
}
