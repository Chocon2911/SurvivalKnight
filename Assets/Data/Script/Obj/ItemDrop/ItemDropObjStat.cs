using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropObjStat : BaseObj
{
    //==========================================Variable==========================================
    [Header("ItemDrop Obj Stat")]
    public string ObjDropId;
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
        this.ObjDropId = RandomString.GetRandomId(20);
        this.ObjType = ObjType.ItemDrop;
    }
}
