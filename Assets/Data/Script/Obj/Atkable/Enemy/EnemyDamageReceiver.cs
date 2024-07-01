using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy DamageReceiver")]
    [Header("Script")]
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //======================================Damage Receiver=======================================
    protected override void DespawnObj()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
    }

    public override void DefaultStat()
    {
        base.DefaultStat();
        if (this.manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.atkDamage = this.manager.Stat.Health;
        this.atkObjType = this.manager.Stat.AtkObjType;
    }
}
