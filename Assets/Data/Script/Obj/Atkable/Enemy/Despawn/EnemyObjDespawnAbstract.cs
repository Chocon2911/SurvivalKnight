using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyObjDespawnAbstract : Despawner
{
    [Header("Enemy Obj Despawn")]
    [SerializeField] protected EnemyObjDespawn despawnManager;
    public EnemyObjDespawn DespawnManager => despawnManager;

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
        this.despawnManager = transform.parent.GetComponent<EnemyObjDespawn>();
        Debug.LogWarning(transform.name + ": Load DespawnManager", transform.gameObject);
    }

    //==========================================Despawn===========================================
    public override void DespawnObj()
    {
        EnemySpawner.Instance.Despawn(this.despawnManager.Manager.transform);
    }
}
