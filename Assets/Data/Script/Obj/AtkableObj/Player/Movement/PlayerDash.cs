using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : PlayerMovementAbstract
{
    #region Variable
    [Header("Player Dash")]
    [Header("Stat")]
    [SerializeField] protected float dashSpeed;
    public float DashSpeed => dashSpeed;

    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;

    [SerializeField] protected float cooldownDelay;
    public float CooldownDelay => cooldownDelay;

    [SerializeField] protected float cooldownTimer;
    public float CooldownTimer => cooldownTimer;

    [SerializeField] protected float dashTime;
    public float DashTime => dashTime;

    [SerializeField] protected bool canDash;
    public bool CanDash => canDash;

    [SerializeField] protected bool isDash;
    public bool IsDash => isDash;
    #endregion



    #region Unity
    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckIfCanDash();
    }

    protected virtual void Update()
    {
        this.Dash();
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfCanDash()
    {
        if (this.isDash) return;
        if (cooldownTimer >= cooldownDelay)
        {
            this.canDash = true;
            return;
        }

        this.canDash = false;
        this.cooldownTimer += Time.fixedDeltaTime;
    }
    #endregion



    #region Dash
    //============================================Dash============================================
    protected virtual void Dash()
    {
        if (!this.canDash) return;
        if (!InputManager.Instance.Dash) return;

        Vector4 moveDir = InputManager.Instance.MoveDir;
        if (moveDir == Vector4.zero) return;

        this.DoDash(moveDir);
    }

    protected virtual void DoDash(Vector4 moveDir)
    {
        this.cooldownTimer = 0;
        this.canDash = false;
        this.isDash = true;

        StartCoroutine(Dashing(moveDir));
    }

    protected virtual IEnumerator Dashing(Vector4 moveDir)
    {
        Vector2 dashDir = new Vector2(moveDir.x - moveDir.z, moveDir.y - moveDir.w);
        
        this.movement.Manager.Rb.velocity = dashDir * this.dashSpeed * this.moveSpeed;
        yield return new WaitForSeconds(this.dashTime);

        this.FinishDash();
    }

    protected virtual void FinishDash()
    {
        this.isDash = false;
    }
    #endregion



    #region Other
    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        if (this.movement.Manager.Stat == null) return;

        this.dashSpeed = this.movement.Manager.Stat.DashSpeed;
        this.moveSpeed = this.movement.Manager.Stat.MoveSpeed;
        this.cooldownDelay = this.movement.Manager.Stat.DashCooldown;
        this.dashTime = this.movement.Manager.Stat.DashTime;
    }
    #endregion
}
