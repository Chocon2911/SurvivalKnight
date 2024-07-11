using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByInputVelocity : MoveByVelocity
{
    //======================================Move By Velocity======================================
    protected override void Move()
    {
        //Condition here
        this.moveDir = InputManager.Instance.MoveDir;
        this.DoMove();
    }
}
