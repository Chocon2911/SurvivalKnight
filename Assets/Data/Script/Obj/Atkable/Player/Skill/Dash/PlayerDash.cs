using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : DashSkill
{
    [Header("Player Dash")]
    // Other
    [SerializeField] protected PlayerDashSkillSO so;
    public PlayerDashSkillSO SO => so;

    // Script
    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        // Other
        this.LoadSO();
        // Script
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

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Skill/CharacterSkill/Dash/Player/Dash_1";
        this.so = Resources.Load<PlayerDashSkillSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }
    
    // Script
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

        // Activate Skill
        this.DashDir = InputManager.Instance.MoveDir;
        this.ActivateSkill();
    }

    protected override void UseSkill()
    {
        base.UseSkill();

        // Deactive Move by Keyboard
        this.skill.Manager.Movement.KeyBoard.SetCanMove(false);
        this.skill.Manager.Movement.KeyBoard.StopMove();
    }

    protected override void ChargeSkill()
    {

    }

    protected override void FinishDoing()
    {
        base.FinishDoing();
        this.rb.velocity = Vector2.zero;
        this.skill.Manager.Movement.KeyBoard.SetCanMove(true);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        if (this.so == null)
        {
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }

        // Base Skill
        this.CooldownDelay = this.so.CooldownDelay;
        this.ChargeDelay = this.so.ChargingDelay;
        this.DoingLength = this.so.DoingTime;

        // Dash Skill
        this.DashSpeed = this.so.DashSpeed;
    }
}
