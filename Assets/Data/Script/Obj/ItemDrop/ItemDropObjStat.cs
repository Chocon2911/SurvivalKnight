using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropObjStat : BaseObj
{
    //==========================================Variable==========================================
    public ItemDropObjType ItemDropObjType;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DefaultStat();
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.ItemDrop;
    }
}
