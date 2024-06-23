using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjSkill : PlayerObjAbstract
{
    [Header("Player Obj Skill")]
    [Header("Script")]
    [SerializeField] protected PlayerObjDash dash;
    public PlayerObjDash Dash => dash;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDash();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDash()
    {
        if (this.dash != null) return;
        this.dash = transform.GetComponentInChildren<PlayerObjDash>();
        Debug.LogWarning(transform.name + ": Load Dash", transform.gameObject);
    }
}
