using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerObjManager : HuyMonoBehaviour
{
    #region Variable
    [Header("Player Obj Manager")]
    [Header("Other")]
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [Header("Script")]
    [SerializeField] protected PlayerDamageReceiver damageReceiver;
    public PlayerDamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected PlayerObjCtrl ctrl;
    public PlayerObjCtrl Ctrl => ctrl;
    #endregion



    #region Unity
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRigidbody();

        //Script
        this.LoadDamageReceiver();
        this.LoadCtrl();
    }
    #endregion



    #region Load Component
    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.GetComponentInChildren<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        this.rb.gravityScale = 0;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.isKinematic = false;
        this.rb.mass = 1;
        this.rb.freezeRotation = true;
        Debug.LogWarning(transform.name + ": Load Rigidbody", transform.gameObject);
    }

    //Script
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<PlayerDamageReceiver>();
        Debug.LogWarning(transform.name + ": Load DamageReceiver", transform.gameObject);
    }

    protected virtual void LoadCtrl()
    {
        if (this.ctrl != null) return;
        this.ctrl = transform.GetComponent<PlayerObjCtrl>();
        Debug.LogWarning(transform.name + ": Load Ctrl", transform.gameObject);
    }
    #endregion
}
