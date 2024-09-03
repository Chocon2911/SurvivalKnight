using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTargetByLerp : MovementTrans
{
    //=======================================Movement Trans=======================================
    protected override void Move()
    {
        base.Move();
    }

    //==========================================Movement==========================================
    protected override void DoMove()
    {
        base.DoMove();
        float zPos = this.moveObj.position.z;
        Vector2 newPos = Vector2.Lerp(this.moveObj.position, this.target.position, this.MoveSpeed * Time.fixedDeltaTime);
        this.moveObj.position = new Vector3 (newPos.x, newPos.y, zPos);
    }
}
