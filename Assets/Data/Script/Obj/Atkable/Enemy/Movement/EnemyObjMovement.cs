using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjMovement : HuyMonoBehaviour
{
    [Header("Enemy Movement")]
    // Script
    [SerializeField] protected EnemyObjManager manager;
    public EnemyObjManager Manager => manager;

    [SerializeField] protected EnemyObjChaseOpponent chaseOpponent;
    public EnemyObjChaseOpponent ChaseOpponent => chaseOpponent;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Script
        this.LoadManager();
        this.LoadChaseOpponent();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected virtual void LoadChaseOpponent()
    {
        if (this.chaseOpponent != null) return;
        this.chaseOpponent = transform.Find("ChaseOpponent").GetComponent<EnemyObjChaseOpponent>();
        Debug.LogWarning(transform.name + ": Load ChaseOpponent", transform.gameObject);
    }
}
