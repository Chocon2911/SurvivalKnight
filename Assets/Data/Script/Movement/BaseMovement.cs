using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : HuyMonoBehaviour
{
    [Header("Base Movement")]
    //Stat
    public float MoveSpeed;

    [SerializeField] protected bool canMove;
    public bool CanMove => canMove;

    [SerializeField] protected bool isMoving;
    public bool IsMoving => isMoving;


    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //============================================Set=============================================
    protected virtual void SetCanMove(bool canMove)
    {
        this.canMove = canMove;
    }

    //==========================================Movement==========================================
    protected virtual void Move()
    {
        if (!this.canMove) return;
    }

    protected virtual void DoMove()
    {
        this.isMoving = true;
    }

    public virtual void StopMove()
    {
        this.isMoving = false;
    }
}
