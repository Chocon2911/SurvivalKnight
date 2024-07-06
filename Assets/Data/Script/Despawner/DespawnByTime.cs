using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DespawnByTime : Despawner
{
    public virtual float DespawnDelay { get; set; }
    public virtual float DespawnTimer { get; set; }

    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.Despawn();
    }

    //==========================================Despawn===========================================
    protected virtual void Despawn()
    {
        if (this.DespawnTimer < this.DespawnDelay)
        {
            this.DespawnTimer += Time.fixedDeltaTime;
            return;
        }

        this.DespawnTimer = 0;
        this.DespawnObj();
    }

    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        this.DespawnTimer = 0;
    }
}

