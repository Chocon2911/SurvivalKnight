using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFlyStraight : HuyMonoBehaviour
{
    [Header("Obj Fly Straight")]
    [Header("Other")]
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected Transform affectedObj;
    public Transform AffectedObj => affectedObj;

    [Header("Stat")]
    [SerializeField] protected float flySpeed;
    public float FlySpeed => flySpeed;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRb();
        this.LoadAffectedObj();
    }

    protected virtual void OnEnable()
    {
        this.Fly();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadRb() //Override if inheritance
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.gravityScale = 0;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }

    protected virtual void LoadAffectedObj() //Override if inheritance
    {
        if (this.affectedObj != null) return;
        this.affectedObj = transform;
        Debug.LogWarning(transform.name + ": Load AffectedObj", transform.gameObject);
    }

    //============================================Fly=============================================
    public virtual void Fly()
    {
        this.rb.velocity = this.GetDir(this.affectedObj.rotation.z) * this.flySpeed;
    }

    protected virtual void StopFly()
    {
        this.rb.velocity = Vector2.zero;
    }

    //============================================Get=============================================
    protected virtual Vector2 GetDir(float angle)
    {
        float xDir = Mathf.Cos(angle);
        float yDir = Mathf.Sin(angle);
        Vector2 dir = new Vector2(xDir, yDir).normalized;

        return dir;
    }
}
