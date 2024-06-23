using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjMovement : ObjMovement
{
    #region Variable
    [Header("Player Move")]
    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        this.LoadManager();
        base.LoadComponent();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    //Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected override void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    protected override void LoadAtkableObjStat()
    {
        if (this.atkableObjStat != null) return;
        this.atkableObjStat = this.manager.Stat;
        Debug.LogWarning(transform.name + ": Load AtkableObjSta", transform.gameObject);
    }
    #endregion



    #region Atkable Obj Movemnt
    //====================================Atkable Obj Movment=====================================
    protected override void Move()
    {
        if (this.manager.Skill.Dash.IsDoing) return;
        this.moveDir = InputManager.Instance.MoveDir;
        base.Move();
    }
    #endregion
}
