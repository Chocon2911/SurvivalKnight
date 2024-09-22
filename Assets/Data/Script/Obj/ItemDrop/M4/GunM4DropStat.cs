using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropStat : ItemDropObjStat
{
    //==========================================Variable==========================================
    [Header("Gun M4Drop Stat")]
    // Script
    [SerializeField] protected GunM4DropManager manager;
    public GunM4DropManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadManager();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<GunM4DropManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.ItemCode = ItemCode.M4;
        this.ObjName = "GunM4";
    }
}
