using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjCtrl : AtkableObjCtrl
{
    [Header("Player Obj Ctrl")]
    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

    //===========================================Unity============================================
    protected virtual void OnEnable()
    {
        this.manager.Stat.DefaultStat();
    }

    protected virtual void Update()
    {
        this.ChooseSKillCtrl();
        this.ActionCtrl();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<PlayerObjManager>();
        Debug.Log(transform.name + ": Load Manager", transform.gameObject);
    }

    //============================================Ctrl============================================
    protected virtual void ActionCtrl()
    {
        if (this.manager.Skill.Dash.IsDoing || this.manager.Skill.Dash.IsCharging) return;
        this.manager.Movement.Move();
        this.manager.Skill.Dash.ActivateSkill();
    }

    protected virtual void ChooseSKillCtrl()
    {
        if (InputManager.Instance.NumberPressed == 10) return;
        if (InputManager.Instance.NumberPressed == 1)
        {
            this.manager.Skill.Shoot.transform.gameObject.SetActive(true);
            this.manager.Skill.Shotgun.transform.gameObject.SetActive(false);
        }

        if (InputManager.Instance.NumberPressed == 2)
        {
            this.manager.Skill.Shoot.transform.gameObject.SetActive(false);
            this.manager.Skill.Shotgun.transform.gameObject.SetActive(true);
        }
    }
}
