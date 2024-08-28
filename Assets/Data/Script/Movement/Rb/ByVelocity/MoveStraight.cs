using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveStraight : MoveByVelocity
{
    //======================================Move By Velocity======================================
    protected override void Move()
    {
        this.MoveDir = Vector2.zero;
        this.MoveDir.x = 1;
        this.DoMove();
    }
}
