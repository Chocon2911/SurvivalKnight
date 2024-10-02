using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class ItemDropObjManager : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Equipment Drop Obj Manager")]
    // Other
    [SerializeField] protected CapsuleCollider2D bodyCollide;
    public CapsuleCollider2D BodyCollide => bodyCollide;

    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    [SerializeField] protected ItemDropSO so;
    public ItemDropSO SO => so;

    // Script
    [SerializeField] protected ItemDropObjStat stat;
    public ItemDropObjStat Stat => stat;

    [SerializeField] protected ItemDropObjDespawn despawn;
    public ItemDropObjDespawn Despawn => despawn;

    [SerializeField] protected ItemDropObjPickedUp pickUp;
    public ItemDropObjPickedUp PickUp => pickUp;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Other
        this.LoadBodyCollide();
        this.LoadModel();
        this.LoadSO();
        
        // Script
        this.LoadStat();
        this.LoadDespawn();
        this.LoadPickUp();
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

    protected virtual void LoadSO()
    {
        if (this.so != null) return;
        string filePath = "ItemDrop/M4";
        this.so = Resources.Load<ItemDropSO>(filePath);
        Debug.LogWarning(transform.name + ": Load SO", transform.gameObject);
    }

    // Script
    protected virtual void LoadStat()
    {
        if (this.stat != null) return;
        this.stat = transform.GetComponent<ItemDropObjStat>();
        Debug.LogWarning(transform.name + ": Load Stat", transform.gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.Find("Despawn").GetComponent<ItemDropObjDespawn>();
        Debug.LogWarning(transform.name + ": Load Despawn", transform.gameObject);
    }

    protected virtual void LoadPickUp()
    {
        if (this.pickUp != null) return;
        this.pickUp = transform.Find("PickUp").GetComponent<ItemDropObjPickedUp>();
        Debug.LogWarning(transform.name + ": Load PickUP", transform.gameObject);
    }
}
