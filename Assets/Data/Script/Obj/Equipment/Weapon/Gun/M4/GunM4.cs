using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunM4 : BaseGun
{
    [Header("Gun M4")]
    [SerializeField] protected M4SO so;
    public M4SO SO => so;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSO();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "Obj/Equipment/Weapon/Gun/M4/M4_1";
        this.so = Resources.Load<M4SO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.ObjName = "M4";
    }
}
