using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementTrans : BaseMovement
{
    [Header("MovementTrans")]
    [Header("Other")]
    [SerializeField] protected Transform moveObj;
    public Transform MoveObj => moveObj;

    [SerializeField] protected Transform target;
    public Transform Target => target;

    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.DoMove();
    }    

    //============================================Set=============================================
    public virtual void SetMoveObj(Transform moveObj)
    {
        this.moveObj = moveObj;
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        this.movementType = MovementType.Translate;
    }
}
