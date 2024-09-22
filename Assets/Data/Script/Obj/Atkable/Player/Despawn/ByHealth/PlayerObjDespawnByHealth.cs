using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjDespawnByHealth : PlayerObjDespawnAbstract
{
    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.CheckIfDead();
    }

    //==========================================Checker===========================================
    protected virtual void CheckIfDead()
    {
        if (this.despawnManager.Manager.DamageReceiver.Hp > 0) return;
        this.DespawnObj();
    }

    //==========================================Despawn===========================================
    public override void DespawnObj()
    {
        this.despawnManager.Manager.transform.gameObject.SetActive(false);
    }
}
