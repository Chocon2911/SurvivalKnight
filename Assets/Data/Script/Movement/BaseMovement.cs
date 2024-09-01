using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : HuyMonoBehaviour
{
    [Header("Base Movement")]
    //Stat
    [SerializeField] protected bool isMoving;
    public bool IsMoving => isMoving;

    public float MoveSpeed;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //==========================================Movement==========================================
    protected virtual void Move()
    {
        this.StopMove();
    } 

    protected virtual void DoMove()
    {
        this.isMoving = true;
    }

    protected virtual void StopMove()
    {
        this.isMoving = false;
    }
}
