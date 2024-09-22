using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DashSkill : CharacterSkill
{
    [Header("Dash Skill")]
    // Other
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected List<IDashSkillObserver> observers = new List<IDashSkillObserver>();
    public List<IDashSkillObserver> Observers => observers;

    // Stat
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

    //==========================================Observer==========================================
    public virtual void AddObserver(IDashSkillObserver observer)
    {
        if (observer == null)
        {
            Debug.LogError(observer + ": observer null", transform.gameObject);
            return;
        }

        this.observers.Add(observer);
    }

    //============================================Dash============================================
    protected override void DoSkill()
    {
        
    }

    protected override void FinishCharging()
    {
        base.FinishCharging();
        if (this.rb == null)
        {
            Debug.LogError(transform.name + ": Rb is null", transform.gameObject);
            return;
        }

        if (this.DashDir == Vector2.zero) this.DashDir = new Vector2(1, 0);

        this.rb.velocity = this.DashSpeed * this.DashDir;
        Debug.Log("Dash");
    }

    protected virtual void OnDashStart()
    {
        foreach(IDashSkillObserver observer in this.observers)
        {
            observer.OnDashStart();
        }
    }

    protected virtual void OnDashFinished()
    {
        foreach(IDashSkillObserver observer in this.observers)
        {
            observer.OnDashFinished();
        }
    }

    //===========================================Skill============================================
    protected override void FinishDoing()
    {
        base.FinishDoing();
        this.rb.velocity = Vector2.zero;
    }
}
