using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class ObjMovement : HuyMonoBehaviour
{
    #region Variable
    [Header("Attackable Obj Movement")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [Header("Stat")]
    [SerializeField] protected Vector4 moveDir;
    public Vector4 MoveDir => moveDir;

    [SerializeField] protected float moveSpeed;
    public float MoveSpeed => moveSpeed;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
    }

    protected virtual void Update()
    {
        this.Move();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    protected abstract void LoadRigidbody();
    #endregion



    #region Movement
    //==========================================Movement==========================================
    public virtual void Move()
    {
        float right = this.moveDir.x;
        float left = this.moveDir.z;
        float up = this.moveDir.y;
        float down = this.moveDir.w;
        Vector2 moveDir = new Vector2(right - left, up - down).normalized;

        this.rb.velocity = moveDir * moveSpeed;
    }
    #endregion
}
