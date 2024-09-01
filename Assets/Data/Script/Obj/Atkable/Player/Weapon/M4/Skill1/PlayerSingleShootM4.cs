using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleShootM4 : PlayerSingleShoot
{
    [Header("Player Single Shoot M4")]
    [SerializeField] protected PlayerGunM4 gunM4;
    public PlayerGunM4 GunM4 => gunM4;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadGunM4();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadGunM4()
    {
        if (this.gunM4 != null) return;
        this.gunM4 = transform.parent.GetComponent<PlayerGunM4>();
        Debug.LogWarning(transform.name + ": Load GunM4", transform.gameObject);
    }

    //===========================================Other============================================
    protected override void DefaultStat()
    {
        base.DefaultStat();
        if (this.gunM4.SO == null)
        {
            Debug.LogError(transform.name + ": so is null", transform.gameObject);
            return;
        }


    }
}
