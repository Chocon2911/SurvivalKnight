using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunM4DropDespawner : GunM4DropAbstract
{
    [Header("Gun M4 Drop Despawner")]
    [SerializeField] protected GunM4DropDespawnByPickUp byPickUp;
    public GunM4DropDespawnByPickUp ByPickUp => byPickUp;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadByPickUp();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadByPickUp()
    {
        if (this.byPickUp != null) return;
        this.byPickUp = transform.Find("ByPickUp").GetComponent<GunM4DropDespawnByPickUp>();
        Debug.LogWarning(transform.name + ": Load ByPickUp", transform.gameObject);
    }
}
