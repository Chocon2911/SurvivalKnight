using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunManager : PlayerWeaponObjManager
{
    [Header("Player Obj Gun")]
    [Header("Script")]
    [SerializeField] protected GunShoot shoot;
    public GunShoot Shoot => shoot;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShoot();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadShoot()
    {
        if (this.shoot != null) return;
        this.shoot = transform.GetComponentInChildren<GunShoot>();
        this.shoot.SetMainObj(this.weaponsManager.Manager.transform);
        Debug.LogWarning(transform.name + ": Load Shoot", transform.gameObject);
    }
}
