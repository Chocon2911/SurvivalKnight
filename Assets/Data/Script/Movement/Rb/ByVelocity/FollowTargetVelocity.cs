using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTargetVelocity : MoveByVelocity
{
    [Header("Follow Target Velocity")]
    [Header("Other")]
    [SerializeField] protected Transform target;
    public Transform Target => target;

    //============================================Set=============================================
    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    //======================================Move By Velocity======================================
    protected override void Move()
    {
        //Any Condition here
        this.DoFollow();
    }

    protected virtual void DoFollow()
    {
        this.moveDir = this.GetDir();
        this.DoMove();
    }

    //============================================Get=============================================
    protected virtual Vector2 GetDir()
    {
        if (this.target == null)
        {
            Debug.LogError(transform.name + ": Target is null", transform.gameObject);
            return Vector2.zero;
        }

        return this.target.position - transform.position;
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        this.movementRbType = MovementRbType.ByVelocity;
    }
}
