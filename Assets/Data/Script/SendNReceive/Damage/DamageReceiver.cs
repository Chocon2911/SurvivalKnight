using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : Damage
{
    [Header("DamageReceiver")]
    [Header("Stat")]
    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    //==========================================Receive===========================================
    public virtual void Receive(float atkDamageReceive)
    {
        this.atkDamage -= atkDamageReceive;
        if (this.atkDamage <= 0) this.isDead = true;
    }

    //===========================================Other============================================
    public override void DefaultStat()
    {
        this.isDead = false;
    }
}
