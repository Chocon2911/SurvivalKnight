using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveByVelocity : MovementRb
{
    [Header("Move By Velocity")]
    public Vector2 MoveDir;

    //==========================================Movement==========================================
    protected override void DoMove()
    {
        base.DoMove();

        if (this.rb == null)
        {
            Debug.LogError(transform.name + ": Rb is null", transform.gameObject);
            return;
        }

        this.rb.velocity = this.MoveDir.normalized * MoveSpeed;
    }

    protected override void StopMove()
    {
        if (this.rb == null)
        {
            Debug.LogError(transform.name + ": Rb is null", transform.gameObject);
            return;
        }

        this.rb.velocity = Vector2.zero;
    }
}
