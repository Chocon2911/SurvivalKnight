using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropObjDespawnByPickUp : Despawner, IItemDropObjPickedUpObserver
{
    //==========================================Variable==========================================
    [Header("Item Drop Despawn By Time")]
    [SerializeField] protected ItemDropObjDespawn despawner;
    public ItemDropObjDespawn Despawner => despawner;

    //===========================================Unity============================================
    protected override void Awake()
    {
        base.Awake();
        this.despawner.Manager.PickUp.RegisterObserver(this);
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawner();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.parent.GetComponent<ItemDropObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Despawner", transform.gameObject);
    }

    //==========================================Despawn===========================================
    public override void DespawnObj()
    {
        ItemDropSpawner.Instance.Despawn(this.despawner.Manager.transform);
    }

    //==========================================Observer==========================================
    public void OnItemPickedUp()
    {
        this.DespawnObj();
    }
}
