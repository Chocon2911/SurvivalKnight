using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkableObjSkill : HuyMonoBehaviour
{
    #region Variable
    [Header("Attackable Obj Skill")]
    [Header("Stat")]
    [SerializeField] protected float cooldownDelay;
    public float CooldownLimit => cooldownDelay;

    [SerializeField] protected float cooldownTimer;
    public float CooldownDelay => cooldownDelay;

    [SerializeField] protected float doingTime;
    public float DoingTime => doingTime;

    [SerializeField] protected bool isReady;
    public bool IsSkillReady => isReady;

    [SerializeField] protected bool isDoing;
    public bool IsDoing => isDoing;
    #endregion



    #region Unity
    protected virtual void FixedUpdate()
    {
        this.CheckIfSkillIsReady();
    }
    #endregion



    #region Skill
    //===========================================Skill============================================
    protected virtual void UseSkill()
    {
        this.cooldownTimer = 0;
        this.isReady = false;
        this.isDoing = true;
    }

    protected virtual void FinishUsingSkill()
    {
        this.isDoing = false;
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfSkillIsReady()
    {
        if (this.isDoing) return;
        if (this.cooldownTimer >= this.cooldownDelay)
        {
            this.isReady = true;
            return;
        }

        this.isReady = false;
        this.cooldownTimer += Time.fixedDeltaTime;
    }
    #endregion
}
