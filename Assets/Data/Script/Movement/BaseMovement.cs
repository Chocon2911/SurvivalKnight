using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : HuyMonoBehaviour
{
    [Header("Base Movement")]
    [Header("Stat")]
    [SerializeField] protected MovementType movementType;
    public MovementType MovementType => movementType;

    [SerializeField] protected bool isMoving;
    public bool IsMoving => isMoving;

    public float MoveSpeed;

    //===========================================Unity============================================
    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.DefaultStat();
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

    //===========================================Other============================================
    protected abstract void DefaultStat();
}
