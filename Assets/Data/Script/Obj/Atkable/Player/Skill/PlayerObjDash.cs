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
    #endregion



    #region Unity
    protected virtual void Update()
    {
        this.Dash();
    }

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
    protected virtual void Dash()
    {
        if (!this.isReady) return;
        if (!InputManager.Instance.Dash) return;

        Vector4 moveDir = InputManager.Instance.MoveDir;
        if (moveDir == Vector4.zero) return;

        this.DoDash(moveDir);
    }

    protected virtual void DoDash(Vector4 moveDir)
    {
        this.UseSkill();
        StartCoroutine(Dashing(moveDir));
    }

    protected virtual IEnumerator Dashing(Vector4 moveDir)
    {
        Vector2 dashDir = new Vector2(moveDir.x - moveDir.z, moveDir.y - moveDir.w);
        
        this.skill.Manager.Rb.velocity = dashDir * this.dashSpeed * this.moveSpeed;
        yield return new WaitForSeconds(this.doingTime);

        this.FinishUsingSkill();
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        if (this.skill.Manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.dashSpeed = this.skill.Manager.Stat.DashSpeed;
        this.moveSpeed = this.skill.Manager.Stat.MoveSpeed;
        this.cooldownDelay = this.skill.Manager.Stat.DashCooldown;
        this.cooldownTimer = this.cooldownDelay;
        this.doingTime = this.skill.Manager.Stat.DashTime;

        //Debug.Log(transform.name + ": Load DefaultStat", transform.gameObject);
    }
    #endregion
}
