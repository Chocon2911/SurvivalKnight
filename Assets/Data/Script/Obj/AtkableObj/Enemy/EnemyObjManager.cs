using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyObjManager : HuyMonoBehaviour
{
    [Header("Other")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRb();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    protected virtual void LoadRb()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.isKinematic = false;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.gravityScale = 0;
        this.rb.mass = 0.1f;
        Debug.LogWarning(transform.name + ": Load Rb", transform.gameObject);
    }
}
