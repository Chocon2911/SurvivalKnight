using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunM4 : BaseGun
{
    [Header("Gun M4")]
    [SerializeField] protected M4SO so;
    public M4SO SO => so;

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.ObjName = "M4";
    }
}
