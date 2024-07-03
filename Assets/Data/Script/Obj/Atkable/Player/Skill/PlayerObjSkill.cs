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

    [SerializeField] protected PlayerShotgun shotgun;
    public PlayerShotgun Shotgun => shotgun;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Script
        this.LoadDash();
        this.LoadShoot();
        this.LoadShotgun();
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

    protected virtual void LoadShotgun()
    {
        if (this.shotgun != null) return;
        this.shotgun = transform.GetComponentInChildren<PlayerShotgun>();
        Debug.LogWarning(transform.name + ": Load Shotgun", transform.gameObject);
    }    
}
