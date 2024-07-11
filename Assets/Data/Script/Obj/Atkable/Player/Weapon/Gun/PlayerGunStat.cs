using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunStat : GunStat
{
    [Header("Player Gun Stat")]
    [Header("Script")]
    [SerializeField] protected PlayerGunManager manager;
    public PlayerGunManager Manager => manager;

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
        this.manager = transform.GetComponent<PlayerGunManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }
}
 