using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetByLerp : MovementTrans
{
    //=======================================Movement Trans=======================================
    protected override void Move()
    {
        this.DoMove();
    }

    //==========================================Movement==========================================
    protected virtual void DoMove()
    {
        this.moveObj.position = Vector3.Lerp(this.moveObj.position, this.target.position, this.MoveSpeed * Time.fixedDeltaTime);
    }
}
