using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : HuyMonoBehaviour
{
    #region Variable
    [Header("Attackable Obj Skill")]
    [Header("Stat")]
    public float CooldownDelay;
    public float CooldownTimer;
    public float ChargeDelay;
    public float ChargeTimer;
    public float DoingLength;
    public float DoingTimer;

    [SerializeField] protected bool isReady;
    public bool IsReady => isReady;

    [SerializeField] protected bool isCharging;
    public bool IsCharging => isCharging;

    [SerializeField] protected bool isDoing;
    public bool IsDoing => isDoing;
    #endregion



    #region Unity
    protected virtual void LateUpdate()
    {
        this.CheckIfSkillIsReady();
        this.CheckIfCharging();
        this.CheckIfDoing();
    }

    //protected virtual void OnDisable()
    //{
    //    StopAllCoroutines();
    //}
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

    protected virtual void FinishCoolingdown()
    {
        this.isReady = true;
    }

    protected virtual void FinishCharging()
    {
        this.isCharging = false;
        this.isDoing = true;
        this.ChargeTimer = 0;
    }

    protected virtual void FinishDoing()
    {
        this.isDoing = false;
        this.CooldownTimer = 0;
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfSkillIsReady()
    {
        if (this.isDoing || this.isCharging) return;
        if (this.CooldownTimer >= this.CooldownDelay)
        {
            this.FinishCoolingdown();
            return;
        }

        this.CooldownTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfCharging()
    {
        if (!this.isCharging) return;
        if (this.ChargeTimer >= this.ChargeDelay)
        {
            this.FinishCharging();
            return;
        }

        this.ChargeTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfDoing()
    {
        if (!this.isDoing) return;
        if (this.DoingTimer >= this.DoingLength)
        {
            this.FinishDoing();
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
