using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropObjStat : BaseObj
{
    //==========================================Variable==========================================
    [Header("ItemDrop Obj Stat")]
    [SerializeField] protected ItemDropObjManager manager;
    public ItemDropObjManager Manager => manager;

    public ItemType ItemType;
    public ItemCode ItemCode;
    public int Amount;
    public int MaxStack;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
        this.DefaultStat();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<ItemDropObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }


    protected virtual void OnEnable()
    {
        this.DefaultStat();
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.ItemDrop;

        if (this.manager.SO == null)
        {
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }

        ItemDropSO so = this.manager.SO;
        this.ObjName = so.ItemName;
        this.ItemType = so.ItemType;
        this.ItemCode = so.ItemCode;
        this.MaxStack = so.MaxStack;
    }
}
