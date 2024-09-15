using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropDespawner : GunM4DropAbstract
{
    [Header("Gun M4 Drop Despawner")]
    [SerializeField] protected GunM4DropDespawnByPickUp byPickUp;
    public GunM4DropDespawnByPickUp ByPickUp => byPickUp;

    [SerializeField] protected GunM4DropDespawnByTime byTime;
    public GunM4DropDespawnByTime ByTime => byTime;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        // Script
        this.LoadByPickUp();
        this.LoadByTime();
    }

    //=======================================Load Component=======================================
    // Script
    protected virtual void LoadByPickUp()
    {
        if (this.byPickUp != null) return;
        this.byPickUp = transform.Find("ByPickUp").GetComponent<GunM4DropDespawnByPickUp>();
        Debug.LogWarning(transform.name + ": Load ByPickUp", transform.gameObject);
    }

    protected virtual void LoadByTime()
    {
        if (this.byTime != null) return;
        this.byTime = transform.Find("ByTime").GetComponent<GunM4DropDespawnByTime>();
        Debug.LogWarning(transform.name + ": Load ByTime", transform.gameObject);
    }
}
