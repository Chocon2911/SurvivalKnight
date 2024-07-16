using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveByVelocity : MovementRb
{
    [Header("Move By Velocity")]
    [Header("Stat")]
    [SerializeField] protected Vector2 moveDir;
    public Vector2 MoveDir => moveDir;

    //==========================================Movement==========================================
    protected override void DoMove()
    {
        if (this.rb == null)
        {
            Debug.LogError(transform.name + ": Rb is null", transform.gameObject);
            return;
        }

        this.rb.velocity = this.moveDir.normalized * MoveSpeed;
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
