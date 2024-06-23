using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjFollowTargetByVelocity : ObjMovement
{
    [SerializeField] protected Transform target;
    public Transform Target => target;

    //===========================================Unity============================================
    protected override void Update()
    {
        this.Follow();
    }

    //============================================Set=============================================
    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    //============================================Get=============================================
    protected virtual Vector2 GetDir()
    {
        if (this.target == null)
        {
            Debug.LogError(transform.name + ": Target is null", transform.gameObject);
            return Vector2.zero;
        }

        Vector2 dir = this.target.position - transform.position;
        return dir;
    }

    //===========================================Follow===========================================
    protected virtual void Follow()
    {
        if (this.target == null) return;

        this.moveDir = this.GetDir();
        this.Move();
    }

    protected virtual void UnFollow()
    {
        this.rb.velocity = Vector2.zero;
    }
}
