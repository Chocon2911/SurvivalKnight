using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerObjManager : HuyMonoBehaviour
{
    #region Variable
    [Header("Player Obj Manager")]
    [Header("Other")]
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected CapsuleCollider2D body;
    public CapsuleCollider2D Body => body;

    [Header("Script")]
    [SerializeField] protected PlayerObjMovement movement;
    public PlayerObjMovement Movement => movement;

    [SerializeField] protected PlayerObjSkill skill;
    public PlayerObjSkill Skill => skill;

    [SerializeField] protected PlayerObjStat stat;
    public PlayerObjStat Stat => stat;
    #endregion



    #region Unity
    protected virtual void OnEnable()
    {
        this.stat.DefaultStat();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.LoadModel();
        this.LoadRigidbody();
        this.LoadBody();

        //Script
        this.LoadMovement();
        this.LoadSkill();
        this.LoadStat();
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

    protected virtual void LoadBody()
    {
        if (this.body != null) return;
        this.body = transform.GetComponent<CapsuleCollider2D>();
        this.body.isTrigger = false;
        this.body.size = new Vector2(1, 1);
        Debug.LogWarning(transform.name + ": Load Body", transform.gameObject);
    }

    //Script
    protected virtual void LoadMovement()
    {
        if (this.movement != null) return;
        this.movement = transform.GetComponentInChildren<PlayerObjMovement>();
        Debug.LogWarning(transform.name + ": Load Movement", transform.gameObject);
    }

    protected virtual void LoadSkill()
    {
        if (this.skill != null) return;
        this.skill = transform.GetComponentInChildren<PlayerObjSkill>();
        Debug.LogWarning(transform.name + ": Load Skill", transform.gameObject);
    }

    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<PlayerObjStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }
    #endregion
}
