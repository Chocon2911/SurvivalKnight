using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDespawnByHealth : EnemyObjDespawnAbstract
{
    //==========================================Variable==========================================
    [Header("Enemy Obj Despawn By Health")]
    // Script
    [SerializeField] protected List<IEnemyObjDespawnByHealthObserver> observers = new List<IEnemyObjDespawnByHealthObserver>();
    public List<IEnemyObjDespawnByHealthObserver> Observers => observers;

    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.CheckIfEnemyDead();
    }

    //==========================================Despawn===========================================
    protected virtual void CheckIfEnemyDead()
    {
        if (this.despawnManager.Manager.DamageReceiver.Hp > 0) return;

        this.OnDespawn();
        this.DespawnObj();
    }

    //==========================================Observer==========================================
    protected virtual void OnDespawn()
    {
        foreach (IEnemyObjDespawnByHealthObserver observer in this.observers)
        {
            observer.OnDespawn();
        }
    }
    
    public virtual void AddObserver(IEnemyObjDespawnByHealthObserver observer)
    {
        this.observers.Add(observer);
    }
}
