using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropObjAbstract : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Equipment Drop Obj Abstract")]
    [SerializeField] protected ItemDropObjManager manager;
    public ItemDropObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<ItemDropObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
