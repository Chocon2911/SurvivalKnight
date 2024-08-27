using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : BaseObj
{
    [Header("Base Weapon")]
    // Other
    [SerializeField] protected SpriteRenderer model;
    public SpriteRenderer Model => model;

    //Script
    [SerializeField] protected List<WeaponSkill> weaponSkills;
    public List<WeaponSkill> WeaponSkills => weaponSkills;

    [SerializeField] protected WeaponType weaponType;
    public WeaponType WeaponType => weaponType;

    //===========================================Unity============================================
    protected override void LoadComponent()
    {
        base.LoadComponent();
        //Other
        this.DefaultStat();
        this.LoadModel();
        //Script
        this.LoadWeaponSkills();
    }

    //=======================================Load Component=======================================
    //Other
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model").GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load Model", transform.gameObject);
    }

    //Script
    protected virtual void LoadWeaponSkills()
    {
        if (this.weaponSkills.Count > 0) return;
        foreach(Transform child in transform)
        {
            WeaponSkill skill = child.GetComponent<WeaponSkill>();
            if (skill != null) this.weaponSkills.Add(skill);
        }
        
        Debug.LogWarning(transform.name + ": Load WeaponSkills", transform.gameObject);
    }

    //===========================================Other============================================
    protected virtual void DefaultStat()
    {
        this.ObjType = ObjType.Equipment;
    }
}
