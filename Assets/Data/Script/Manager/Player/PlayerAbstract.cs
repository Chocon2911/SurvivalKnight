using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : HuyMonoBehaviour
{
    //==========================================Variable==========================================
    [Header("Player Abstract")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

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
        this.manager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager");
    }
}
