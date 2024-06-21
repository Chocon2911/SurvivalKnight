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

    [SerializeField] protected bool isSkillReady;
    public bool IsSkillReady => isSkillReady;
    #endregion



    #region Skill
    //===========================================Skill============================================
    public virtual void UseSkill()
    {
        this.cooldownTimer = 0;
        this.isSkillReady = false;
    }
    #endregion



    #region Checker
    //==========================================Checker===========================================
    protected virtual void CheckIfSkillIsReady()
    {
        if (this.cooldownTimer >= this.cooldownDelay)
        {
            this.isSkillReady = true;
            return;
        }

        this.isSkillReady = false;
        this.cooldownTimer += Time.fixedDeltaTime;
    }
    #endregion



    #region Set
    //============================================Set=============================================
    public virtual void SetCooldownDelay(float cooldownDelay)
    {
        this.cooldownDelay = cooldownDelay;
    }
    #endregion
}
