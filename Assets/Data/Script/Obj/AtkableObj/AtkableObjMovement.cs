using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public abstract class AtkableObjMovement : HuyMonoBehaviour
{
    #region Variable
    [Header("Attackable Obj Movement")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [Header("Script")]
    [SerializeField] protected AtkableObjStat atkableObjStat;
    public AtkableObjStat AtkableObjStat => atkableObjStat;

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
        this.LoadAtkableObjStat();
    }

    protected virtual void Update()
    {
        this.Move();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    protected abstract void LoadRigidbody();
    protected abstract void LoadAtkableObjStat();
    #endregion



    #region Movement
    //==========================================Movement==========================================
    protected virtual void Move()
    {
        float right = this.moveDir.x;
        float left = this.moveDir.z;
        float up = this.moveDir.y;
        float down = this.moveDir.w;
        Vector2 moveDir = new Vector2(right - left, up - down);

        this.rb.velocity = moveDir * moveSpeed;
    }
    #endregion



    #region Other
    //===========================================Other============================================
    public virtual void DefaultStat()
    {
        if (this.atkableObjStat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }

        this.moveSpeed = this.atkableObjStat.MoveSpeed;
    }
    #endregion
}
