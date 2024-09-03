using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseObj
{
    [Header("Base Weapon")]
    // Other
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.DefaultStat();
        this.LoadModel();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }
    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.Equipment;
    }
}
