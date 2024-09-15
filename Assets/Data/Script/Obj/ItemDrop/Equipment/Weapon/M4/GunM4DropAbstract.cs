using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunM4DropAbstract : HuyMonoBehaviour
{
    [Header("Gun M4 Drop Abstract")]
    [SerializeField] protected GunM4DropManager manager;
    public GunM4DropManager Manager => manager;

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
        this.manager = transform.parent.GetComponent<GunM4DropManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
