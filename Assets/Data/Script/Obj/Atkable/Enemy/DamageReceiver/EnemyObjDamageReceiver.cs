using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjDamageReceiver : DamageReceiver
{
    //==========================================Variable==========================================
    [Header("Enemy Obj Damage Receiver")]
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
        this.DefaultStat();
    }

    protected virtual void OnEnable()
    {
        this.Revive();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //======================================Damage Receiver=======================================
    protected virtual void Revive()
    {
        if (this.manager.SO == null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        this.Hp = this.manager.SO.Health;
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        if (this.manager.SO == null)
        {
            Debug.LogError(transform.name + ": SO is null", transform.gameObject);
            return;
        }

        this.Hp = this.manager.SO.Health;
        this.AtkObjType = AtkObjType.Enemy;
    }
}
