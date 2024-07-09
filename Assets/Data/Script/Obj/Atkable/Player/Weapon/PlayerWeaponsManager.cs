using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponsManager : HuyMonoBehaviour
{
    [Header("Player Weapons Manager")]
    [Header("Other")]
    [SerializeField] protected List<PlayerWeaponObjManager> weapons;
    public List<PlayerWeaponObjManager> Weapons => weapons;

    [Header("Script")]
    [SerializeField] protected PlayerObjManager manager;
    public PlayerObjManager Manager => manager;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadManager();
        this.LoadWeapons();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadManager()
    {
        if (this.manager != null) return;
        this.manager = transform.parent.GetComponent<PlayerObjManager>();
        Debug.LogWarning(transform.name + ": Load Manager", transform.gameObject);
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach(Transform weaponObj in transform)
        {
            PlayerWeaponObjManager weaponObjManager = weaponObj.transform.GetComponent<PlayerWeaponObjManager>();
            this.weapons.Add(weaponObjManager);
        }

        Debug.LogWarning(transform.name + ": Load Weapons", transform.gameObject);
    }
}
