using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : Damage
{
    [Header("DamageReceiver")]
    [Header("Stat")]
    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    [SerializeField] protected AtkObjType atkObjType;
    public AtkObjType AtkObjType => atkObjType;

    //==========================================Receive===========================================
    public virtual void Receive(float atkDamageReceive)
    {
        this.atkDamage -= atkDamageReceive;
        if (this.atkDamage <= 0) this.isDead = true;

        this.CheckIfDead();
    }

    protected abstract void DespawnObj();

    //==========================================Checker===========================================
    protected virtual void CheckIfDead()
    {
        if (!this.isDead) return;
        this.DespawnObj();
    }

    //===========================================Other============================================
    public override void DefaultStat()
    {
        this.isDead = false;
    }
}
