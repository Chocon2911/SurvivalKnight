using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : HuyMonoBehaviour
{
    [Header("Damage Receiver")]
    [Header("Stat")]
    public float Hp;

    [SerializeField] protected bool isDead;
    public bool IsDead => isDead;

    //Get Set
    public AtkObjType AtkObjType;

    //===========================================Unity============================================
    protected virtual void OnEnable()
    {
        this.Revive();
    }

    //==========================================Receive===========================================
    public virtual void Receive(float atkDamageReceive)
    {
        this.Hp -= atkDamageReceive;
        if (this.Hp <= 0) this.CheckIfDead();
    }

    protected virtual void Revive()
    {
        this.isDead = false;
    }

    protected abstract void DespawnObj();

    //==========================================Checker===========================================
    protected virtual void CheckIfDead()
    {
        if (this.isDead) return;
        this.isDead = true;
        this.DespawnObj();
    }
}
