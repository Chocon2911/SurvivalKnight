using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjChaseOpponent_Target : HuyMonoBehaviour
{
    // Script
    [SerializeField] protected EnemyObjChaseOpponent chaseOpponent;
    public EnemyObjChaseOpponent ChaseOpponent => chaseOpponent;

    // Stat
    public Vector3 TargetPos;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadChaseOpponent();
    }

    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateCurrPos();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadChaseOpponent()
    {
        if (this.chaseOpponent != null) return;
        this.chaseOpponent = transform.parent.GetComponent<EnemyObjChaseOpponent>();
        Debug.LogWarning(transform.name + ": Load ChaseOpponent", transform.gameObject);
    }

    //===========================================Update===========================================
    protected virtual void UpdateCurrPos()
    {
        transform.position = TargetPos;
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.TargetPos = Vector3.zero;
    }
}
