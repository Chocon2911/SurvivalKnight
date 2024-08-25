using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSkill : BaseSkill
{
    [Header("WeaponSkill")]
    [SerializeField] protected BaseWeapon weapon;
    public BaseWeapon Weapon => weapon;

    [SerializeField] protected WeaponSkillCode weaponSkillCode;
    public WeaponSkillCode WeaponSkillCode => weaponSkillCode;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadWeapon();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadWeapon()
    {
        if (this.weapon != null) return;
        this.weapon = transform.parent.GetComponent<BaseWeapon>();
        Debug.LogWarning(transform.name + ": Load Weapon", transform.gameObject);
    }
}
