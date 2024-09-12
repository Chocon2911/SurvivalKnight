using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTargetPosVelocity : FollowTargetVelocity
{
    [Header("Follow Target pos Velocity")]
    [SerializeField] protected Vector3 targetPos;
    public Vector3 TargetPos => targetPos;

    //===================================Follow Target Velocity===================================
    protected override Vector2 GetDir()
    {
        if (this.target == null) return Vector2.zero;
        
        this.targetPos = this.target.position;
        return this.targetPos - this.rb.transform.position;
    }
}
