using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerObjDash : BaseSkill
{
    #region Variable
    [Header("Player Dash")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    //==========================================Get Set===========================================
    public override float CooldownDelay
    {
        get => this.skill.Manager.Stat.DashCooldown;
        set => this.skill.Manager.Stat.DashCooldown = value;
    }
    public override float CooldownTimer
    {
        get => this.skill.Manager.Stat.DashChargeTimer;
        set => this.skill.Manager.Stat.DashChargeTimer = value;
    }
    public override float ChargeDelay => this.skill.Manager.Stat.DashChargeTime;
    public override float ChargeTimer
    {
        get => this.skill.Manager.Stat.DashChargeTimer;
        set => this.skill.Manager.Stat.DashChargeTimer = value;
    }
    public override float DoingLength
    {
        get => this.skill.Manager.Stat.DashTime;
        set => this.skill.Manager.Stat.DashTime = value;
    }
    public override float DoingTimer
    {
        get => this.skill.Manager.Stat.DashTimer;
        set => this.skill.Manager.Stat.DashTimer = value;
    }
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



    #region Dash
    //============================================Dash============================================
    public override void ActivateSkill()
    {
        if (!transform.gameObject.activeSelf) return;
        if (!InputManager.Instance.Dash) return;

        base.ActivateSkill();
    }

    protected override void ChargeSkill()
    {
        this.isCharging = false;
        this.isDoing = true;
    }

    protected override void DoSkill()
    {
        Vector4 moveDir = InputManager.Instance.MoveDir;
        float dashSpeed = this.skill.Manager.Stat.DashSpeed;
        float moveSpeed = this.skill.Manager.Stat.MoveSpeed;

        Vector2 dashDir = new Vector2(moveDir.x - moveDir.z, moveDir.y - moveDir.w);
        this.skill.Manager.Rb.velocity = dashDir * dashSpeed * moveSpeed;
    }
    #endregion
}
