using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDespawnByHealth : EnemyObjDespawnAbstract
{
    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.CheckIfEnemyDead();
    }

    //==========================================Despawn===========================================
    protected virtual void CheckIfEnemyDead()
    {
        if (this.despawnManager.Manager.DamageReceiver.Hp > 0) return;
        this.DespawnObj();
    }
}
