using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipmentDropDespawnByTime : DespawnByTime
{
    [Header("EquipmentDrop Despawn By Time")]
    [SerializeField] protected ItemDropObjStat stat;
    public ItemDropObjStat Stat => stat;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadStat();
    }

    //=========================================Despawner==========================================
    public override void DespawnObj()
    {
        EquipmentDropSpawner.Instance.Despawn(this.stat.transform);
    }

    //=======================================Load Component=======================================
    protected abstract void LoadStat();
}
