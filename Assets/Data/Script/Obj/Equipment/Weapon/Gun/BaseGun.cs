using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGun : BaseWeapon
{
    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.weaponType = WeaponType.Gun;
    }
}
