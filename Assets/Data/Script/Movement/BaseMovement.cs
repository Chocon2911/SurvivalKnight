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

    protected virtual void Update()
    {
        this.Move();
    }

    //==========================================Movement==========================================
    protected abstract void Move();
    protected virtual void DoMove()
    {
        this.isMoving = true;
    }
    protected abstract void StopMove();

    //===========================================Other============================================
    protected abstract void DefaultStat();
}
