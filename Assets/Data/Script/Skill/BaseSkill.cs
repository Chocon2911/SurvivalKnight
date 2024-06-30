using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSkill : HuyMonoBehaviour
{
    #region Variable
    [Header("Attackable Obj Skill")]
    [Header("Stat")]
    [SerializeField] protected float cooldownDelay;
    public float CooldownLimit => cooldownDelay;

    [SerializeField] protected float cooldownTimer;
    public float CooldownDelay => cooldownDelay;

    [SerializeField] protected float chargeDelay;
    public float ChargeDelay => chargeDelay;

    [SerializeField] protected float chargeTimer;
    public float ChargeTimer => chargeTimer;

    [SerializeField] protected float doingLength;
    public float DoingLength => doingLength;

    [SerializeField] protected float doingTimer;
    public float DoingTimer => doingTimer;

    [SerializeField] protected bool isReady;
    public bool IsSkillReady => isReady;

    [SerializeField] protected bool isCharging;
    public bool IsCharging => isCharging;

    [SerializeField] protected bool isDoing;
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
        this.cooldownTimer = 0;
        this.isReady = false;
        this.isCharging = true;
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfSkillIsReady()
    {
        if (this.cooldownDelay == 0) return;
        if (this.isDoing || this.isCharging) return;
        if (this.cooldownTimer >= this.cooldownDelay)
        {
            this.isReady = true;
            return;
        }

        this.cooldownTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfCharging()
    {
        if (this.chargeDelay == 0) return;
        if (!this.isCharging) return;
        if (this.chargeTimer >= this.chargeDelay)
        {
            this.isCharging = false;
            this.isDoing = true;
            this.chargeTimer = 0;
            return;
        }

        this.chargeTimer += Time.fixedDeltaTime;
    }

    protected virtual void CheckIfDoing()
    {
        if (this.doingLength == 0) return;
        if (!this.isDoing) return;
        if (this.doingTimer >= this.doingLength)
        {
            this.isDoing = false;
            this.doingTimer = 0;
            return;
        }

        this.doingTimer += Time.fixedDeltaTime;
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        this.isDoing = false;
        this.isReady = false;
        this.cooldownTimer = 0;
        this.chargeTimer = 0;
        this.doingTimer = 0;
    }
    #endregion
}
