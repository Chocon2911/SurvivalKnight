using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveStraight : MoveByVelocity
{
    //======================================Move By Velocity======================================
    protected override void Move()
    {
        this.moveDir = Vector2.zero;
        this.moveDir.x = 1;
        this.DoMove();
    }
}
