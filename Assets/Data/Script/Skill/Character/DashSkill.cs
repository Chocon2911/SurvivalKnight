using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DashSkill : CharacterSkill
{
    [Header("Dash Skill")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [Header("Stat")]
    public Vector2 DashDir;
    public float DashSpeed;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRb();
    }

    //=======================================Load Component=======================================
    protected abstract void LoadRb();

    //============================================Set=============================================
    protected virtual void SetDashDir(Vector2 dashDir)
    {
        this.DashDir = dashDir;
    }

    //============================================Dash============================================
    protected override void DoSkill()
    {
        if (this.rb == null)
        {
            Debug.LogError(transform.name + ": Rb is null", transform.gameObject);
            return;
        }

        this.rb.velocity = this.DashSpeed * this.DashDir;
    }

    //===========================================Skill============================================
    protected override void FinishDoing()
    {
        base.FinishDoing();
        this.rb.velocity = Vector2.zero;
    }
}
