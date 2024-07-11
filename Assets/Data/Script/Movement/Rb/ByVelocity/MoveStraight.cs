using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStraight : MoveByVelocity
{
    //======================================Move By Velocity======================================
    protected override void Move()
    {
        this.moveDir.x = 1;
        this.DoMove();
    }
}
