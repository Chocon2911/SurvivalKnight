using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunM4 : GunM4
{
    [Header("Player Gun M4")]
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = transform.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load Weapon", transform.gameObject);
    }
}
