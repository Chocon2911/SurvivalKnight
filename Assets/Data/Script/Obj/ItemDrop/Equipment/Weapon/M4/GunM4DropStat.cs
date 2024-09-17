using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropStat : WeaponDropObjStat
{
    //==========================================Variable==========================================
    [Header("Gun M4Drop Stat")]
    // Script
    [SerializeField] protected GunM4DropManager manager;
    public GunM4DropManager Manager => manager;

    // Stat
    public List<M4Stat> Stats;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadManager();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.GetComponent<GunM4DropManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        if (this.manager == null || this.manager.StatReceiver == null)
        {
            Debug.LogError(transform.name + ": address doesn't exist", transform.gameObject);
            return;
        }

        GunM4DropReceiver receiver = this.manager.StatReceiver;

        // Obj Receiver
        this.ObjName = receiver.ObjName;
        this.ObjDropId = receiver.ObjId;
        
        // GunM4Drop Receiver
        this.Stats = receiver.Stats;
    }
}
