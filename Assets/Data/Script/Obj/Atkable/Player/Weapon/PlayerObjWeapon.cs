using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjWeapon : PlayerObjAbstract
{
    [Header("Player Obj Weapon")]
    [SerializeField] protected List<BaseWeapon> weapons;
    public List<BaseWeapon> Weapons => weapons;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapons();
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateWeapon();
    }

    protected virtual void OnEnable()
    {
        this.DeActiveAllWeapon();
        this.weapons[0].gameObject.SetActive(true);
    }

    //=======================================Load Component=======================================
    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform obj in transform)
        {
            BaseWeapon weapon = obj.GetComponent<BaseWeapon>();
            if (weapon == null) continue;
            
            this.weapons.Add(weapon);
        }

        Debug.LogWarning(transform.name + ": Load Weapons", transform.gameObject);
    }

    //===========================================Weapon===========================================
    protected virtual void UpdateWeapon()
    {
        int numberPressed = InputManager.Instance.NumberPressed - 1;
        if (numberPressed < 0 || numberPressed > this.weapons.Count + 1) return;

        this.DeActiveAllWeapon();
        this.weapons[numberPressed].gameObject.SetActive(true);
    }

    protected virtual void DeActiveAllWeapon()
    {
        foreach (BaseWeapon weapon in this.weapons)
        {
            weapon.gameObject.SetActive(false);
        }
    }
}
