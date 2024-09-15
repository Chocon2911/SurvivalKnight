using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropDespawnByPickUp : Despawner
{
    [Header("Gun M4 Despawn By Pick Up")]
    // Script
    [SerializeField] protected GunM4DropDespawner despawner;
    public GunM4DropDespawner Despawner => despawner;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawner();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.parent.GetComponent<GunM4DropDespawner>();
        Debug.LogWarning(transform.name + ": Load Despawner", transform.gameObject);
    }
}
