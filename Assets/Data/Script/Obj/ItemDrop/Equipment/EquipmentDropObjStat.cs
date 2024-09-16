using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentDropObjStat : ItemDropObjStat
{
    //==========================================Variable==========================================
    [Header("EquipmentDrop Obj Stat")]
    public EquipmentDropObjType EquipmentDropObjType;

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.ItemDropObjType = ItemDropObjType.Equipment;
    }
}
