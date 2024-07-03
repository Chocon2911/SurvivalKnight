using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDash : BaseSkill
{
    #region Variable
    [Header("Player Dash")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    [Header("Stat")]
    [SerializeField] protected float dashSpeed;
    public float DashSpeed => dashSpeed;

    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [SerializeField] protected Vector4 moveDir;
    public Vector4 MoveDir => moveDir;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSkill();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    protected virtual void LoadSkill()
    {
        if (this.skill != null) return;
        this.skill = transform.parent.GetComponent<PlayerObjSkill>();
        Debug.LogWarning(transform.name + ": Load Skill", transform.gameObject);
    }
    #endregion



    #region Get
    //============================================Get=============================================
    protected virtual void GetMoveDir()
    {
        this.moveDir = InputManager.Instance.MoveDir;
    }
    #endregion



    #region Dash
    //============================================Dash============================================
    public virtual void Dash()
    {
        this.GetMoveDir();

        if (this.isReady && InputManager.Instance.Dash)
        {
            this.UseSkill();
        }

        if (this.isCharging)
        {
            this.ChargeDash();
        }

        if (this.isDoing)
        {
            this.DoDash();
        }
    }

    protected virtual void ChargeDash()
    {
        this.isCharging = false;
        this.isDoing = true;
    }

    protected virtual void DoDash()
    {
        Vector2 dashDir = new Vector2(this.moveDir.x - moveDir.z, moveDir.y - moveDir.w);
        this.skill.Manager.Rb.velocity = dashDir * this.dashSpeed * this.moveSpeed;
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public override void DefaultStat()
    {
        base.DefaultStat();

        if (this.skill.Manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.dashSpeed = this.skill.Manager.Stat.DashSpeed;
        this.moveSpeed = this.skill.Manager.Stat.MoveSpeed;
        this.cooldownDelay = this.skill.Manager.Stat.DashCooldown;
        this.chargeDelay = this.skill.Manager.Stat.DashChargeTime;
        this.doingLength = this.skill.Manager.Stat.DashTime;

        //Debug.Log(transform.name + ": Load DefaultStat", transform.gameObject);
    }
    #endregion
}
