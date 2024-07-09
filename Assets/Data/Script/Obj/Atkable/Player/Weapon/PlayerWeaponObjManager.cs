using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerWeaponObjManager : WeaponManager
{
    [Header("Player Weapon Obj Manager")]
    [Header("Script")]
    [SerializeField] protected PlayerWeaponsManager weaponsManager;
    public PlayerWeaponsManager WeaponsManager => weaponsManager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeaponsManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadWeaponsManager()
    {
        if (this.weaponsManager != null) return;
        this.weaponsManager = transform.parent.GetComponent<PlayerWeaponsManager>();
        Debug.LogWarning(transform.name + ": Load WeaponsManger", transform.gameObject);
    }
}
