using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropObjStat : BaseObj
{
    //==========================================Variable==========================================
    [Header("ItemDrop Obj Stat")]
    public ItemType ItemType;
    public ItemCode ItemCode;
    public int Amount;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DefaultStat();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.ItemDrop;
    }
}
