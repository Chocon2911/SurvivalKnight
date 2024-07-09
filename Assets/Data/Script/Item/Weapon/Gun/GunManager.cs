using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : WeaponManager
{
    [Header("Gun Manager")]
    [Header("Script")]
    [SerializeField] protected GunStat stat;
    public GunStat Stat => stat;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStat();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<GunStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }
}
