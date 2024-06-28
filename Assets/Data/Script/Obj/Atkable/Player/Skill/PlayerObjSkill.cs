using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjSkill : PlayerObjAbstract
{
    [Header("Player Obj Skill")]
    [Header("Script")]
    [SerializeField] protected PlayerObjDash dash;
    public PlayerObjDash Dash => dash;

    [SerializeField] protected PlayerObjShoot shoot;
    public PlayerObjShoot Shoot => shoot;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDash();
        this.LoadShoot();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDash()
    {
        if (this.dash != null) return;
        this.dash = transform.GetComponentInChildren<PlayerObjDash>();
        Debug.LogWarning(transform.name + ": Load Dash", transform.gameObject);
    }

    protected virtual void LoadShoot()
    {
        if (this.shoot != null) return;
        this.shoot = transform.GetComponentInChildren<PlayerObjShoot>();
        Debug.LogWarning(transform.name + ": Load Shoot", transform.gameObject);
    }
}
