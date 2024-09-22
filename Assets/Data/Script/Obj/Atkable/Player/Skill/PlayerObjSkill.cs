using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjSkill : PlayerObjAbstract
{
    [Header("Player Obj Skill")]
    // Script
    [SerializeField] protected PlayerDash dash;
    public PlayerDash Dash => dash;

    // Stat
    [SerializeField] protected int maxSkillAmount;
    public int MaxSkillAmount => maxSkillAmount;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDash();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadDash()
    {
        if (this.dash != null) return;
        this.dash = transform.Find("Dash").GetComponent<PlayerDash>();
        Debug.LogWarning(transform.name + ": Load Dash", transform.gameObject);
    }
}
