using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTargetVelocity : MoveByVelocity
{
    [Header("Follow Target Velocity")]
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
        base.Move();
        this.DoMove();
    }

    protected override void DoMove()
    {
        this.MoveDir = this.GetDir();
        base.DoMove();
    }

    //============================================Get=============================================
    protected virtual Vector2 GetDir()
    {
        if (this.target == null) return Vector2.zero;

        return this.target.position - transform.position;
    }
}
