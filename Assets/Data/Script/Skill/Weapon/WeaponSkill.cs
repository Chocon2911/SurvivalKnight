using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponSkill : BaseSkill
{
    [Header("WeaponSkill")]
    // Script
    [SerializeField] protected BaseWeapon weapon;
    public BaseWeapon Weapon => weapon;

    //Stat
    public WeaponSkillCode WeaponSkillCode;
    public float Damage;
    public List<AtkObjType> AtkObjTypes;

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
