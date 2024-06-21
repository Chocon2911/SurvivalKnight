using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : AtkableObjMovement
{
    #region Variable
    [SerializeField] protected PlayerMovementManager movement;
    public PlayerMovementManager Movement => movement;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        this.LoadMovement();
        base.LoadComponent();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<PlayerMovementManager>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected override void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    protected override void LoadAtkableObjStat()
    {
        if (this.atkableObjStat != null) return;
        this.atkableObjStat = this.movement.Manager.Stat;
        Debug.LogWarning(transform.name + ": Load AtkableObjSta", transform.gameObject);
    }
    #endregion



    #region Atkable Obj Movemnt
    //====================================Atkable Obj Movment=====================================
    protected override void Move()
    {
        if (this.movement.Dash.IsDash) return;
        this.moveDir = InputManager.Instance.MoveDir;
        base.Move();
    }
    #endregion
}
