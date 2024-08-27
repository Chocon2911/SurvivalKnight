using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHoldRange : WeaponHoldRange
{
    [Header("Player Gun M4 Hold Range")]
    [SerializeField] protected PlayerObjWeapon weapon;
    public PlayerObjWeapon Weapon => weapon;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
    }

    protected virtual void OnEnable()
    {
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is null", transform.gameObject);
            return;
        }

        this.SetMainObj(this.weapon.Manager.transform);
        this.SetTargetObj(GameManager.Instance.MouseObj);
    }    

    //=======================================Load Component=======================================
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = transform.parent.parent.GetComponent<PlayerObjWeapon>();
        Debug.LogWarning(transform.name + ": Load Weapon", transform.gameObject);
    }
}
