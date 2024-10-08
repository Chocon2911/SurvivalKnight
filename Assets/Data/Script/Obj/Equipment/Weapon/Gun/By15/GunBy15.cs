using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunBy15 : BaseGun
{
    [Header("Gun By15")]
    [SerializeField] protected By15SO so;
    public By15SO SO => so;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        this.LoadSO();
        base.LoadComponent();
    }

    //=======================================Load Component=======================================
    protected abstract void LoadSO();
}
