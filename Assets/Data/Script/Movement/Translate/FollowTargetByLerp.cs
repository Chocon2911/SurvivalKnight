using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTargetByLerp : MovementTrans
{
    //=======================================Movement Trans=======================================
    protected override void Move()
    {
        this.DoMove();
    }

    //==========================================Movement==========================================
    protected override void DoMove()
    {
        this.moveObj.position = Vector3.Lerp(this.moveObj.position, this.target.position, this.MoveSpeed * Time.fixedDeltaTime);
    }
}
