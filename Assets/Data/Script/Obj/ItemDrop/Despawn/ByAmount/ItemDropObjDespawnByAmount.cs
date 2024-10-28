using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropObjDespawnByAmount : Despawner
{
    [Header("ItemDropObj Despawn By Amount")]
    [SerializeField] protected ItemDropObjDespawn despawner;
    public ItemDropObjDespawn Despawnwer => despawner;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawner();
    }

    protected virtual void FixedUpdate()
    {
        this.CheckIfZeroAmount();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.parent.GetComponent<ItemDropObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Despawner", transform.gameObject);
    }

    //=========================================Despawner==========================================
    public override void DespawnObj()
    {
        ItemDropSpawner.Instance.Despawn(this.despawner.Manager.transform);
    }

    protected virtual void CheckIfZeroAmount()
    {
        if (this.despawner.Manager.Stat.Amount > 0) return;
        this.DespawnObj();
    }
}
