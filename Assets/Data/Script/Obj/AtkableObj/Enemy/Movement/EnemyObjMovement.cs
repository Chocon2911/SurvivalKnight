using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjMovement : AtkableObjMovement
{
    [Header("Enemy Obj Movement")]
    [SerializeField] protected EnemyObjManager mananger;
    public EnemyObjManager Mananger => mananger;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadManager();
        base.LoadComponent();
    }

    //====================================Atkable Obj Movement====================================
    protected override void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = this.mananger.Rb;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    protected override void LoadAtkableObjStat()
    {
        
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.mananger != null) return;
        this.mananger = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": Load Manager", transform.gameObject);
    }
}
