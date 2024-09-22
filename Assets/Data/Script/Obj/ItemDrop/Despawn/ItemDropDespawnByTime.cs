using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropObjDespawnByTime : DespawnByTime
{
    //==========================================Variable==========================================
    [Header("Item Drop Despawn By Time")]
    [SerializeField] protected ItemDropObjStat stat;
    public ItemDropObjStat Stat => stat;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStat(); 
    }

    //=======================================Load Component=======================================
    protected abstract void LoadStat();

    //==========================================Despawn===========================================
    public override void DespawnObj()
    {
        ItemDropSpawner.Instance.Despawn(this.stat.transform);
    }
}
