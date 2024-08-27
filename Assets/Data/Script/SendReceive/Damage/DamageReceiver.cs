using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : DamageSR
{
    [Header("DamageReceiver")]
    [Header("Stat")]
    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    //Get Set
    public AtkObjType AtkObjType;

    //==========================================Receive===========================================
    public virtual void Receive(float atkDamageReceive)
    {
        this.AtkDamage -= atkDamageReceive;
        if (this.AtkDamage <= 0) this.CheckIfDead();
    }

    protected abstract void DespawnObj();

    //==========================================Checker===========================================
    protected virtual void CheckIfDead()
    {
        if (this.isDead) return;
        this.isDead = true;
        this.DespawnObj();
    }

    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        this.isDead = false;
    }
}
