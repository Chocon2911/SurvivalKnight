using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveByKeyBoard : MoveByVelocity, IDashSkillObserver
{
    [SerializeField] protected PlayerObjMovement movement;
    public PlayerObjMovement Movement => movement;

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

    //=======================================Load Component=======================================
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.parent.GetComponent<PlayerObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    //============================================Get=============================================
    protected virtual void GetDir()
    {
        this.MoveDir = InputManager.Instance.MoveDir;
    }

    //======================================Move By Velocity======================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.movement.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected override void Execute()
    {
        this.StopMove();
        this.DoMove();
    }

    protected override void DoMove()
    {
        this.GetDir();
        if (this.MoveDir == Vector2.zero) return;

        base.DoMove();
    }

    //====================================Dash Skill Observer=====================================
    public void OnDashStart()
    {
        Debug.Log(transform.name + ": On Dash Start", transform.gameObject);
        this.canMove = false;
    }

    public void OnDashFinished()
    {
        Debug.Log(transform.name + ": On Dash Finished", transform.gameObject);
        this.canMove = true;
    }
}
