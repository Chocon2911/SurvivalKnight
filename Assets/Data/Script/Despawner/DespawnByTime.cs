using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DespawnByTime : Despawner
{
    [Header("Despawn By Time")]
    [Header("Stat")]
    [SerializeField] protected float despawnDelay;
    public float DespawnDelay => despawnDelay;

    [SerializeField] protected float despawnTimer;
    public float DespawnTimer => despawnTimer;

    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.Despawn();
    }

    //==========================================Despawn===========================================
    protected virtual void Despawn()
    {
        if (this.despawnTimer < this.despawnDelay)
        {
            this.despawnTimer += Time.fixedDeltaTime;
            return;
        }

        this.despawnTimer = 0;
        this.DespawnObj();
    }

    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        this.despawnTimer = 0;
    }
}

