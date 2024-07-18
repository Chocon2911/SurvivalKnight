using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : DashSkill
{
    [Header("Player Dash")]
    [Header("Script")]
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSkill();
        base.LoadComponent();
    }

    protected virtual void Update()
    {
        this.Dash();
    }

    //=========================================Dash Skill=========================================
    protected override void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = this.skill.Manager.Rb;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected override void ChargeSkill() { }

    //=======================================Load Component=======================================
    protected virtual void LoadSkill()
    {
        if (this.skill != null) return;
        this.skill = transform.parent.GetComponent<PlayerObjSkill>();
        Debug.LogWarning(transform.name + ": Load Skill", transform.gameObject);
    }

    //============================================Dash============================================
    protected virtual void Dash()
    {
        if (!InputManager.Instance.Dash) return;
        this.ActivateSkill();
    }
}
