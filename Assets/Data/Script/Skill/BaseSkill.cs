using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : HuyMonoBehaviour
{
    #region Variable
    public float CooldownDelay;
    public float CooldownTimer;
    public float ChargeDelay;
    public float ChargeTimer;
    public float DoingLength;
    public float DoingTimer;

    [Header("Attackable Obj Skill")]
    [Header("Stat")]
    [SerializeField] protected bool isReady;
    [SerializeField] protected bool isCharging;
    [SerializeField] protected bool isDoing;

    public bool IsReady => isReady;
    public bool IsCharging => isCharging;
    public bool IsDoing => isDoing;
    #endregion



    #region Unity
    protected virtual void FixedUpdate()
    {
        this.CheckIfSkillIsReady();
        this.CheckIfCharging();
        this.CheckIfDoing();
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }
    #endregion



    #region Skill
    //===========================================Skill============================================
    public virtual void ActivateSkill()
    {
        if (this.isReady)
        {
            this.UseSkill();
        }

        if (this.isCharging)
        {
            this.ChargeSkill();
        }

        if (this.isDoing)
        {
            this.DoSkill();
        }
    }
    
    protected virtual void UseSkill()
    {
        this.CooldownTimer = 0;
        this.isReady = false;
        this.isCharging = true;
    }

    protected abstract void ChargeSkill();
    protected abstract void DoSkill();

    protected virtual void FinishCharging()
    {
        this.isCharging = false;
        this.isDoing = true;
    }

    protected virtual void FinshDoing()
    {
        this.isDoing = false;
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfSkillIsReady()
    {
        if (this.CooldownDelay == 0) return;
        if (this.isDoing || this.isCharging) return;
        if (this.CooldownTimer >= this.CooldownDelay)
        {
            this.isReady = true;
            return;
        }

        this.CooldownTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfCharging()
    {
        if (this.ChargeDelay == 0) return;
        if (!this.isCharging) return;
        if (this.ChargeTimer >= this.ChargeDelay)
        {
            this.isCharging = false;
            this.isDoing = true;
            this.ChargeTimer = 0;
            return;
        }

        this.ChargeTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfDoing()
    {
        if (this.DoingLength == 0) return;
        if (!this.isDoing) return;
        if (this.DoingTimer >= this.DoingLength)
        {
            this.isDoing = false;
            this.DoingTimer = 0;
            return;
        }

        this.DoingTimer += Time.fixedDeltaTime;
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        this.isDoing = false;
        this.isCharging = false;
        this.isReady = false;
    }
    #endregion
}
