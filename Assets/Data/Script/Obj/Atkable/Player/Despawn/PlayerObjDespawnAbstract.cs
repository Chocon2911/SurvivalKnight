using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerObjDespawnAbstract : Despawner
{
    //==========================================Variable==========================================
    [Header("Player OBj Despawn Abstract")]
    [SerializeField] protected PlayerObjDespawn despawnManager;
    public PlayerObjDespawn DespawnManager => despawnManager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawnManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadDespawnManager()
    {
        if (this.despawnManager != null) return;
        this.despawnManager = transform.parent.GetComponent<PlayerObjDespawn>();
        Debug.LogWarning(transform.name + ": Load DespawnManager", transform.gameObject);
    }
}
