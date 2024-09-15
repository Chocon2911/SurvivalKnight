using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDropObjStat : EquipmentDropObjStat
{
    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.EquipmentDropObjType = EquipmentDropObjType.Weapon;
    }
}
