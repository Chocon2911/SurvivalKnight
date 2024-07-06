using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : HuyMonoBehaviour
{
    #region Variable
    public virtual float CooldownDelay { get; set; }
    public virtual float CooldownTimer { get; set; }
    public virtual float ChargeDelay { get; set; }
    public virtual float ChargeTimer { get; set; }
    public virtual float DoingLength { get; set; }
    public virtual float DoingTimer { get; set; }

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
    protected virtual void UseSkill()
    {
        this.CooldownTimer = 0;
        this.isReady = false;
        this.isCharging = true;
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
