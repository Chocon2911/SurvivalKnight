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

    [SerializeField] protected ItemDropObjDespawnByAmount byAmount;
    public ItemDropObjDespawnByAmount ByAmount => ByAmount;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadByTime();
        this.LoadByAmount();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadByTime()
    {
        if (this.byTime != null) return;
        this.byTime = transform.Find("ByTime").GetComponent<ItemDropObjDespawnByTime>();
        Debug.LogWarning(transform.name + ": Load ByTime", transform.gameObject);
    }

    protected virtual void LoadByAmount()
    {
        if (this.byAmount != null) return;
        this.byAmount = transform.Find("ByAmount").GetComponent<ItemDropObjDespawnByAmount>();
        Debug.LogWarning(transform.name + ": Load ByAmount", transform.gameObject);
    }
}
