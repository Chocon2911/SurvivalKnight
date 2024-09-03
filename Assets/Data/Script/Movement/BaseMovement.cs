using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : HuyMonoBehaviour
{
    [Header("Base Movement")]
    //Stat
    public float MoveSpeed;

    [SerializeField] protected bool isMoving;
    public bool IsMoving => isMoving;


    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //==========================================Movement==========================================
    protected virtual void Move()
    {
        this.StopMove();
        this.DoMove();
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
