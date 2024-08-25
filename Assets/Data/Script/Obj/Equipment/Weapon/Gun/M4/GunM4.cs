using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunM4 : BaseGun
{
    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.ObjName = "M4";
    }
}
