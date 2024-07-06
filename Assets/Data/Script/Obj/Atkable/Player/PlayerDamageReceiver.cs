using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("Player Damage Receiver")]
    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

    //Get Set
    public override float AtkDamage 
    { 
        get => this.manager.Stat.AtkDamage; 
        set => this.manager.Stat.AtkDamage = value;
    }
    public override AtkObjType AtkObjType 
    { 
        get => this.manager.Stat.AtkObjType; 
        set => this.manager.Stat.AtkObjType = value;
    }

    //=======================================Load Component=======================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    //======================================Damage Receiver=======================================
    protected override void DespawnObj()
    {
        
    }

    public override void DefaultStat()
    {
        base.DefaultStat();

        if (this.manager.Stat == null)
        {
            Debug.LogError(transform.name + ": Stat is null", transform.gameObject);
            return;
        }
    }
}
