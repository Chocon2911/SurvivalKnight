using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : FollowTargetByLerp
{
    //===========================================Unity============================================
    protected virtual void OnEnable()
    {
        this.canMove = true;
    }
}
