using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjFollowTargetByLerp : HuyMonoBehaviour
{
    [Header("OBj Follow Target By Lerp")]
    [Header("Other")]
    [SerializeField] protected Transform target;
    public Transform Target => target;

    [Header("Stat")]
    [SerializeField] protected float moveSpeed = 1;
    public float MoveSpeed => moveSpeed;

    //===========================================Unity============================================
    protected virtual void FixedUpdate()
    {
        this.Follow();
    }

    //============================================Set=============================================
    protected virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    //===========================================Follow===========================================
    protected virtual void Follow()
    {
        if (target == null) return;

        Vector2 newPos;
        newPos = Vector2.Lerp(transform.parent.position, this.target.position, moveSpeed);
        transform.parent.position = new Vector3 (newPos.x, newPos.y, transform.parent.position.z);
    }
}
