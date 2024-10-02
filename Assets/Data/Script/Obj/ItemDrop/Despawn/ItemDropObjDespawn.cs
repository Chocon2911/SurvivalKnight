using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ItemDropObjDespawn : ItemDropObjAbstract
{
    //==========================================Variable==========================================
    [Header("Equipment Drop Obj Despawn")]
    [SerializeField] protected ItemDropObjDespawnByTime byTime;
    public ItemDropObjDespawnByTime ByTime => ByTime;

    [SerializeField] protected ItemDropObjDespawnByPickUp byPickUp;
    public ItemDropObjDespawnByPickUp ByPickUp => byPickUp;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadByTime();
        this.LoadbyPickUp();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadByTime()
    {
        if (this.byTime != null) return;
        this.byTime = transform.Find("ByTime").GetComponent<ItemDropObjDespawnByTime>();
        Debug.LogWarning(transform.name + ": Load ByTime", transform.gameObject);
    }

    protected virtual void LoadbyPickUp()
    {
        if (this.byPickUp != null) return;
        this.byPickUp = transform.Find("ByPickUp").GetComponent<ItemDropObjDespawnByPickUp>();
        Debug.LogWarning(transform.name + ": Load ByPickUp", transform.gameObject);
    }
}
