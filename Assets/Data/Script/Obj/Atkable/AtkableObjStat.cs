using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AtkableObjStat : BaseObj
{
    #region Variable
    public AtkObjType AtkObjType;
    #endregion

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DefaultStat();
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.AtkableObj;
    }
}
