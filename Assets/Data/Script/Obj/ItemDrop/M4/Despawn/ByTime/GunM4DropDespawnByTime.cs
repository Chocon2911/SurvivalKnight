using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropDespawnByTime : ItemDropObjDespawnByTime
{
    [Header("GunM4Drop Despawn By Time")]
    [SerializeField] protected GunM4DropDespawner despawner;
    public GunM4DropDespawner Despawner => despawner;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadDespawner();
        base.LoadComponent();
    }

    //===============================EquipmentDrop Despawn By Time================================
    protected override void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = this.despawner.Manager.Stat;
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.parent.GetComponent<GunM4DropDespawner>();
        Debug.LogWarning(transform.name + ": Load Despawner", transform.gameObject);
    }
}
