using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerObjManager : HuyMonoBehaviour
{
    #region Variable
    [Header("Player Obj Manager")]
    [Header("Other")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [Header("Script")]
    [SerializeField] protected PlayerMovementManager movement;
    public PlayerMovementManager Movement => movement;

    [SerializeField] protected PlayerObjStat stat;
    public PlayerObjStat Stat => stat;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRigidbody();

        //Script
        this.LoadMovement();
        this.LoadStat();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.gravityScale = 0;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    //Script
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<PlayerMovementManager>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<PlayerObjStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }
    #endregion
}
