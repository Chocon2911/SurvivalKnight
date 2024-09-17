using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class GunM4DropManager : HuyMonoBehaviour
{
    [Header("Gun M4 Drop Manager")]
    // Other
    [SerializeField] protected CapsuleCollider2D bodyCollide;
    public CapsuleCollider2D BodyCollide => bodyCollide;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    // Script
    [SerializeField] protected GunM4DropStat stat;
    public GunM4DropStat Stat => stat;

    [SerializeField] protected GunM4DropDespawner despawner;
    public GunM4DropDespawner Despawner => despawner;

    [SerializeField] protected GunM4DropSender statSender;
    public GunM4DropSender StatSender => statSender;

    [SerializeField] protected GunM4DropReceiver statReceiver;
    public GunM4DropReceiver StatReceiver => statReceiver;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Other
        this.LoadBodyCollide();
        this.LoadModel();

        // Script
        this.LoadStat();
        this.LoadDespawner();
        this.LoadStatSender();
        this.LoadStatReceiver();
    }

    //=======================================Load Component=======================================
    // Other
    protected virtual void LoadBodyCollide()
    {
        if (this.bodyCollide != null) return;
        this.bodyCollide = transform.GetComponent<CapsuleCollider2D>();
        Debug.LogWarning(transform.name + ": Load BodyCollide", transform.gameObject);
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    // Script
    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<GunM4DropStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }

    protected virtual void LoadDespawner()
    {
        if (this.despawner != null) return;
        this.despawner = transform.Find("Despawn").GetComponent<GunM4DropDespawner>();
        Debug.LogWarning(transform.name + ": Load Despawner", transform.gameObject);
    }

    protected virtual void LoadStatSender()
    {
        if (this.statSender != null) return;
        this.statSender = transform.Find("StatSender").GetComponent<GunM4DropSender>();
        Debug.LogWarning(transform.name + ": Load StatSender", transform.gameObject);
    }

    protected virtual void LoadStatReceiver()
    {
        if (this.statReceiver != null) return;
        this.statReceiver = transform.Find("StatReceiver").GetComponent<GunM4DropReceiver>();
        Debug.LogWarning(transform.name + ": Load StatReceiver", transform.gameObject);
    }
}
